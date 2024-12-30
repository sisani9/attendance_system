import { Component, OnInit } from '@angular/core';
import { Attendance } from '../../models/attendance.model';
import { AttendanceService } from '../../services/attendance.service';

@Component({
    selector: 'app-attendance-list',
    templateUrl: './attendance-list.component.html',
    styleUrls: ['./attendance-list.component.scss']
})
export class AttendanceListComponent implements OnInit {
    attendances: Attendance[] = [];

    constructor(private attendanceService: AttendanceService) { }

    ngOnInit(): void {
        this.attendanceService.getAttendances().subscribe(data => {
            this.attendances = data;
        });
    }
}
