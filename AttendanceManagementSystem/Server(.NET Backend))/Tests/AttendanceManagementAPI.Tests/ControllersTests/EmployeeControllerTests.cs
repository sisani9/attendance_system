using AttendanceManagementAPI.Controllers;
using AttendanceManagementAPI.Models;
using AttendanceManagementAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Moq; // Install Moq NuGet package
using Xunit; // Install xUnit NuGet package

public class EmployeeControllerTests
{
    [Fact]
    public void GetEmployees_ShouldReturnOkResult()
    {
        // Arrange
        var mockService = new Mock<IEmployeeService>(); // Mock the service
        mockService.Setup(service => service.GetEmployees())
                   .Returns(new List<Employee>()); // Return an empty list for the test

        var controller = new EmployeeController(mockService.Object);

        // Act
        var result = controller.GetEmployees() as OkObjectResult;

        // Assert
        Assert.NotNull(result); // Ensure the result is not null
        Assert.Equal(200, result.StatusCode); // Check if the status code is 200
        Assert.IsType<List<Employee>>(result.Value); // Ensure the returned value is a list of employees
    }
}
