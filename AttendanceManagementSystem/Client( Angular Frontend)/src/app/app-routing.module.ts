import { NgModule } from '@angular/core';
// Correctly import from the appropriate file
import { Employee } from './models/employee.model';

import { RouterModule, Routes } from '@angular/router';
import { EmployeeListComponent } from './components/employee/employee-list/employee-list.component';
import { EmployeeDetailComponent } from './components/employee/employee-detail/employee-detail.component';
import { AttendanceListComponent } from './components/attendance/attendance-list/attendance-list.component';

const routes: Routes = [
    { path: 'employees', component: EmployeeListComponent },
    { path: 'employees/:id', component: EmployeeDetailComponent },
    { path: 'attendance', component: AttendanceListComponent },
    { path: '', redirectTo: '/employees', pathMatch: 'full' } // Default route
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule { }
