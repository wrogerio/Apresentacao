import { Inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Category } from '../interfaces/category';

@Injectable({
  providedIn: 'root',
})
export class CategoryService {
  constructor(
    private http: HttpClient,
    @Inject('API_URL') private apiUrl: string
  ) {}

  getCategories() {
    const url = `${this.apiUrl}/categories`;
    return this.http.get<Category[]>(url);
  }

  getCategory(id: string) {
    const url = `${this.apiUrl}/categories/${id}`;
    return this.http.get<Category>(url);
  }

  createCategory(category: Category) {
    const url = `${this.apiUrl}/categories`;
    return this.http.post<Category>(url, category);
  }

  updateCategory(category: Category) {
    const url = `${this.apiUrl}/categories/${category.id}`;
    return this.http.put<Category>(url, category);
  }

  deleteCategory(id: string) {
    const url = `${this.apiUrl}/categories/${id}`;
    return this.http.delete<Category>(url);
  }
}
