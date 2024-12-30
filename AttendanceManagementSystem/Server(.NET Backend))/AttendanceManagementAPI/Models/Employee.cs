using System.Collections.Generic;

namespace AttendanceManagementAPI.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }

        // Navigation Property: One Employee can have many Attendance records
        public ICollection<Attendance> Attendances { get; set; }
        public object Id { get; internal set; }
    }
}
