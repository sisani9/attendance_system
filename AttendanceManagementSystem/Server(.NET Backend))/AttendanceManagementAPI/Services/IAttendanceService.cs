using AttendanceManagementAPI.Models;

namespace AttendanceManagementAPI.Services
{
    public interface IAttendanceService
    {
        object GetAttendances();
        void MarkAttendance(Attendance attendance);
    }
}