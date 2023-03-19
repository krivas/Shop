import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Product } from '../Models/Product';
import { HttpClient } from '@angular/common/http';


@Injectable({
  providedIn: 'root'
})
export class ProductService {

  apiUrl = 'http://localhost:44494/api/products';

  constructor(private http: HttpClient) { }

  getProducts(): Observable<Product[]> {
    return this.http.get<Product[]>(this.apiUrl);
  }

  addProduct(product: Product): Observable<number> {
    return this.http.post<number>(this.apiUrl, product);
  }

  updateProduct(product: Product): Observable<any> {
    return this.http.put<any>(`${this.apiUrl}`, product);
  }

  deleteProduct(id: number): Observable<any> {
    return this.http.delete<any>(`${this.apiUrl}/${id}`);
  }
}
