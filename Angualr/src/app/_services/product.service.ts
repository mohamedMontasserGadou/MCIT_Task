import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  baseUrl = environment.apiUrl;
  constructor(private http: HttpClient) { }

  getAll(categoryId: number) {
    return this.http.get(this.baseUrl + `product/getAll/${categoryId}`);
  }

  get(id: number) {
    return this.http.get(this.baseUrl + `product/get/${id}`);
  }

  add(data: any) {
    return this.http.post(this.baseUrl + 'product/add', data);
  }

  delete(id: number) {
    return this.http.delete(this.baseUrl + `product/remove/${id}`);
  }

  edit(id: number, data: any) {
    return this.http.put(this.baseUrl + `product/edit/${id}`, data);
  }
}
