using Microsoft.AspNetCore.Mvc;
using AttendanceManagementAPI.Services;
using AttendanceManagementAPI.Models;

namespace AttendanceManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public IActionResult GetEmployees()
        {
            var employees = _employeeService.GetEmployees();
            return Ok(employees);
        }

        [HttpPost]
        public IActionResult AddEmployee(Employee employee)
        {
            _employeeService.AddEmployee(employee);
            return CreatedAtAction(nameof(GetEmployees), new { id = employee.Id }, employee);
        }
    }
}
