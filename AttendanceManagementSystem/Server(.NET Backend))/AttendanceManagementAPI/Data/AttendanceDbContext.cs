using Microsoft.EntityFrameworkCore;
using AttendanceManagementAPI.Models;

namespace AttendanceManagementAPI
{
    public class AttendanceDbContext : DbContext
    {
       // internal object Attendances;

        public AttendanceDbContext(DbContextOptions<AttendanceDbContext> options) 
            : base(options) { }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Attendance> Attendances { get; set; }

        public object Attendance { get; internal set; }
    }
}
