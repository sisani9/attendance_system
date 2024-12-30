import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Attendance } from '../models/attendance.model';

@Injectable({
    providedIn: 'root', // Makes the service available throughout the app
})
export class AttendanceService {
    private apiUrl = 'http://localhost:5000/api/attendance'; // Replace with your backend API endpoint

    constructor(private http: HttpClient) { }

    // Get all attendance records
    getAttendanceRecords(): Observable<Attendance[]> {
        return this.http.get<Attendance[]>(this.apiUrl);
    }

    // Mark attendance
    markAttendance(attendance: Attendance): Observable<Attendance> {
        const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
        return this.http.post<Attendance>(this.apiUrl, attendance, { headers });
    }

    // Get attendance by employee ID
    getAttendanceByEmployeeId(employeeId: number): Observable<Attendance[]> {
        return this.http.get<Attendance[]>(`${this.apiUrl}/employee/${employeeId}`);
    }

    // Update attendance record
    updateAttendance(attendanceId: number, attendance: Attendance): Observable<Attendance> {
        const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
        return this.http.put<Attendance>(`${this.apiUrl}/${attendanceId}`, attendance, { headers });
    }

    // Delete attendance record
    deleteAttendance(attendanceId: number): Observable<void> {
        return this.http.delete<void>(`${this.apiUrl}/${attendanceId}`);
    }
}
