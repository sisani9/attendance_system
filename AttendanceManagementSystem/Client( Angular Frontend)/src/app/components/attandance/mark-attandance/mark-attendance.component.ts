import { Component } from '@angular/core';
import { AttendanceService } from '../../services/attendance.service';
import { Attendance } from '../../models/attendance.model';

@Component({
    selector: 'app-mark-attendance',
    templateUrl: './mark-attendance.component.html',
    styleUrls: ['./mark-attendance.component.scss']
})
export class MarkAttendanceComponent {
    attendance: Attendance = { id: 0, employeeId: 0, date: '', status: '' };

    constructor(private attendanceService: AttendanceService) { }

    markAttendance(): void {
        this.attendanceService.markAttendance(this.attendance).subscribe(() => {
            alert('Attendance marked successfully!');
        });
    }
}
