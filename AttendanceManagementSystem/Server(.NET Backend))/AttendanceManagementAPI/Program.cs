using Microsoft.EntityFrameworkCore;
using AttendanceManagementAPI.Repositories;
using AttendanceManagementAPI.Services;
using AttendanceManagementAPI.Models;
using AttendanceManagementAPI;

public class Demo
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container
        builder.Services.AddDbContext<AttendanceDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

        // Add CORS policy for allowing requests from the Angular app
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowFrontend", policy =>
            {
                policy.WithOrigins("http://localhost:4200") // Angular app URL
                      .AllowAnyHeader()
                      .AllowAnyMethod();
            });
        });

        // Add repository and service for Employee
        builder.Services.AddScoped<AttendanceManagementAPI.Repositories.IEmployeeRepository, EmployeeRepository>();
        var serviceCollection = builder.Services.AddScoped<IEmployeeService, AttendanceManagementAPI.EmployeeService>();

        // Add controllers (API controllers)
        builder.Services.AddControllers();

        var app = builder.Build();

        // Configure the HTTP request pipeline
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error"); // Handle exceptions in production
        }

        app.UseHttpsRedirection();  // Enforce HTTPS
        app.UseStaticFiles();       // Serve static files like JS/CSS
        app.UseCors("AllowFrontend"); // Enable CORS policy
        app.UseAuthorization();     // Add Authorization middleware

        app.MapControllers();       // Map API controllers

        app.Run();                  // Start the application
    }
}
