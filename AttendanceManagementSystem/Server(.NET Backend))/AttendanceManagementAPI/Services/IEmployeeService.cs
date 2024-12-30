using AttendanceManagementAPI.Models;

namespace AttendanceManagementAPI.Services
{
    public interface IEmployeeService
    {
        void AddEmployee(Employee employee);
        object GetEmployees();
    }
}