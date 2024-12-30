import { Component } from '';
import { EmployeeService } from '../../services/employee.service';
import { Employee } from '../../models/employee.model';



@Component({
    selector: 'app-employee-form',
    templateUrl: './employee-form.component.html',
    styleUrls: ['./employee-form.component.scss']
})
export class EmployeeFormComponent {
    employee: Employee = { id: 0, name: '', department: '', position: '', email: '', phone: '' };

    constructor(private employeeService: EmployeeService) { }

    onSubmit(): void {
        this.employeeService.addEmployee(this.employee).subscribe(() => {
            alert('Employee added successfully!');
        });
    }
}
