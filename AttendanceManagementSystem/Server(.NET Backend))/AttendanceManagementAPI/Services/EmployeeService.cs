using AttendanceManagementAPI.Models;
using AttendanceManagementAPI.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AttendanceManagementAPI.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        // Constructor that accepts IEmployeeRepository
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        // GetEmployees method - Uses async/await since it's calling an async method
        public async Task<List<Employee>> GetEmployees()
        {
            return await _employeeRepository.GetAllEmployeesAsync(); // Calling the async method
        }

        // AddEmployee method
        public async Task AddEmployee(Employee employee)
        {
            await _employeeRepository.AddEmployeeAsync(employee); // Asynchronous operation
        }

        void IEmployeeService.AddEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }

        object IEmployeeService.GetEmployees()
        {
            throw new NotImplementedException();
        }

        // If you have any additional unimplemented methods, remove them if not required
    }
}
