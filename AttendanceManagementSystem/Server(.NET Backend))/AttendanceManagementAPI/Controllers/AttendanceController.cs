using Microsoft.AspNetCore.Mvc;
using AttendanceManagementAPI.Models;
using AttendanceManagementAPI.Services;


namespace AttendanceManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceController(IAttendanceService attendanceService) : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAttendances()
        {
            var attendances = attendanceService.GetAttendances();
            return Ok(attendances);
        }

        [HttpPost]
        public IActionResult MarkAttendance(Attendance attendance)
        {
            attendanceService.MarkAttendance(attendance);
            return CreatedAtAction(nameof(GetAttendances), new { id = attendance.Id }, attendance);
        }
    }
}
