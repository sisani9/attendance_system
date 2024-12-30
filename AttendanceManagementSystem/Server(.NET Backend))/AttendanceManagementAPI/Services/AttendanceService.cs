using AttendanceManagementAPI.Models;
using AttendanceManagementAPI.Repositories;

namespace AttendanceManagementAPI.Services
{
    public class AttendanceService : IAttendanceService
    {
        private readonly IAttendanceRepository _attendanceRepository;

        public AttendanceService(IAttendanceRepository attendanceRepository)
        {
            _attendanceRepository = attendanceRepository;
        }

        public List<Attendance> GetAttendances()
        {
            return _attendanceRepository.GetAll();
        }

        public void MarkAttendance(Attendance attendance)
        {
            _attendanceRepository.Add(attendance);
        }

        object IAttendanceService.GetAttendances()
        {
            throw new NotImplementedException();
        }
    }
}
