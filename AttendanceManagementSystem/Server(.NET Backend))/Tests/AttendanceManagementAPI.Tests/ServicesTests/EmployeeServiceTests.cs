using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using Moq;

namespace AttendanceManagementAPI
{
    // Employee Model
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    // IEmployeeRepository Interface
    public interface IEmployeeRepository
    {
        Task AddEmployeeAsync(Employee employee);
        Task<List<Employee>> GetAllEmployeesAsync(); // Task<List<Employee>> must be returned
    }

    // EmployeeService Implementation
    public class EmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<List<Employee>> GetAllEmployeesAsync()
        {
            return await _employeeRepository.GetAllEmployeesAsync(); // Await the repository method
        }
    }

    // Unit Test for EmployeeService
    public class EmployeeServiceTests
    {
        [Fact]
        public async Task GetAllEmployees_ShouldReturnListOfEmployees()
        {
            // Arrange: Create a mock for the IEmployeeRepository
            var mockRepo = new Mock<IEmployeeRepository>();

            // Setup mock behavior: When GetAllEmployeesAsync is called, return a mock list of employees
            mockRepo.Setup(repo => repo.GetAllEmployeesAsync())
                    .ReturnsAsync(new List<Employee>
                    {
                        new Employee { Id = 1, Name = "Amit Radhan" },
                        new Employee { Id = 2, Name = "Kishor Dahal" }
                    });

            // Create an instance of EmployeeService and pass in the mock repository
            var employeeService = new EmployeeService(mockRepo.Object);

            // Act: Call the async method and await the result
            var result = await employeeService.GetAllEmployeesAsync();

            // Assert: Verify that the result is not null and contains the expected number of employees
            Assert.NotNull(result);  // Ensure the result is not null
            Assert.IsType<List<Employee>>(result);  // Ensure it's a List<Employee>
            Assert.Equal(2, result.Count);  // Ensure there are two employees in the list
            Assert.Equal("Amit Radhan", result[0].Name); // Verify the first employee's name
            Assert.Equal("Kishor Dahal", result[1].Name); // Verify the second employee's name
        }
    }
}
