import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { DatePredictionDto } from '../models/datePrediction.model';
import { OrdenesDto } from '../models/ordenes.model';
import { InsertarOrdenDto } from '../models/insertarOrden.model';

@Injectable({
  providedIn: 'root'
})
export class OrdersService {
  private URL = 'https://localhost:7227/api/Orders';
  constructor(private http: HttpClient) { }

  traerPredicciones(): Observable<DatePredictionDto[]>{
    return this.http.get<DatePredictionDto[]>(`${ this.URL }/GetPredictionOrders`);
  }

  traerPrediccionesPorNombreCliente(custName: string): Observable<DatePredictionDto[]>{
    return this.http.get<DatePredictionDto[]>
    (`${ this.URL }/GetPredictionOrdersByCustName?custName=${ custName }`);
  }

  traerOrdenesPorIdCliente(custId: number): Observable<OrdenesDto[]>{
    return this.http.get<OrdenesDto[]>(`${ this.URL }/GetOrdersByCustId?custid=${ custId }`);
  }

  insertarOrden(orden: InsertarOrdenDto): Observable<void>{
    return this.http.post<void>(`${ this.URL }/InsertOrder`, orden);
  }
}
