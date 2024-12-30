import { Component, OnInit } from '@angular/core';
import { Employee } from '../../models/employee.model';
import { EmployeeService } from '../../services/employee.service';

@Component({
    selector: 'app-employee-list',
    templateUrl: './employee-list.component.html',
    styleUrls: ['./employee-list.component.scss']
})
export class EmployeeListComponent implements OnInit {
    employees: Employee[] = [];

    constructor(private employeeService: EmployeeService) { }

    ngOnInit(): void {
        this.employeeService.getEmployees().subscribe(data => {
            this.employees = data;
        });
    }
}
