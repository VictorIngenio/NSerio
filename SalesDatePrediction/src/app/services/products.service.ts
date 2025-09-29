import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ProductDto } from '../models/products.model';

@Injectable({
  providedIn: 'root'
})
export class ProductsService {
  private URL = 'https://localhost:7227/api/Products';
  constructor(private http: HttpClient) { }

  traerProductos(): Observable<ProductDto[]>{
    return this.http.get<ProductDto[]>(`${ this.URL }`);
  }
}
