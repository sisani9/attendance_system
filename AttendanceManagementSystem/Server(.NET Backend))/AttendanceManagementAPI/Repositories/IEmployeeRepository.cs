﻿using System.Collections.Generic;
using System.Threading.Tasks;
using AttendanceManagementAPI.Models;

namespace AttendanceManagementAPI.Repositories
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetAllEmployeesAsync();
        Task<Employee> GetEmployeeByIdAsync(int id);
        Task AddEmployeeAsync(Employee employee);
        Task UpdateEmployeeAsync(Employee employee);
        Task DeleteEmployeeAsync(int id);
    }
}
