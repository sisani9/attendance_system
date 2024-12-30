using AttendanceManagementAPI.Models;
using System.Collections.Generic;

namespace AttendanceManagementAPI.Repositories
{
    public interface IAttendanceRepository
    {
        List<Attendance> GetAll();
        void Add(Attendance attendance);
    }
}
