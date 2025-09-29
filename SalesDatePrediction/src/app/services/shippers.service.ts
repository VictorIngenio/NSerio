import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ShipperDto } from '../models/shippers.model';

@Injectable({
  providedIn: 'root'
})
export class ShippersService {
  private URL = 'https://localhost:7227/api/Shippers';
  constructor(private http: HttpClient) { }

  traerTransportistas(): Observable<ShipperDto[]>{
    return this.http.get<ShipperDto[]>(`${ this.URL }`);
  }
}
