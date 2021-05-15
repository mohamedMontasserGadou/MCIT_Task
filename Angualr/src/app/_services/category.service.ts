import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getAll() {
    return this.http.get(this.baseUrl + 'category/getAll');
  }

  get(id: number) {
    return this.http.get(this.baseUrl + `category/get/${id}`);
  }

  add(data: any) {
    return this.http.post(this.baseUrl + 'category/add', data);
  }

  delete(id: number) {
    return this.http.delete(this.baseUrl + `category/remove/${id}`);
  }

  edit(id: number, data: any) {
    return this.http.put(this.baseUrl + `category/edit/${id}`, data);
  }

}
