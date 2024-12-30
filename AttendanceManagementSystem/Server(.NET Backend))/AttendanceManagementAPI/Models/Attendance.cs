using System;

namespace AttendanceManagementAPI.Models
{
    public class Attendance
    {
        public int AttendanceId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; } // Example: "Present" or "Absent"

        // Navigation Property: Link to Employee
        public Employee Employee { get; set; }
        public object Id { get; internal set; }
    }
}
