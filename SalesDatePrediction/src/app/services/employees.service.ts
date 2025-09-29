import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { EmployeeDto } from '../models/employees.model';

@Injectable({
  providedIn: 'root'
})
export class EmployeesService {
  private URL = 'https://localhost:7227/api/Employees';
  constructor(private http: HttpClient) { }

  traerEmpleados(): Observable<EmployeeDto[]>{
    return this.http.get<EmployeeDto[]>(`${ this.URL }`);
  }
}
