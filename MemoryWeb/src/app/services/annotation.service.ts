import { Inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Annotation } from '../interfaces/annotation';

@Injectable({
  providedIn: 'root',
})
export class AnnotationService {
  constructor(
    private http: HttpClient,
    @Inject('API_URL') private apiUrl: string
  ) {}

  getAnnotations() {
    const url = `${this.apiUrl}/annotations`;
    return this.http.get<Annotation[]>(url);
  }

  getAnnotation(id: string) {
    const url = `${this.apiUrl}/annotations/${id}`;
    return this.http.get<Annotation>(url);
  }

  getAnnotationsByCategory(categoryId: string) {
    const url = `${this.apiUrl}/annotations/GetByCategory/${categoryId}`;
    return this.http.get<Annotation[]>(url);
  }

  createAnnotation(annotation: Annotation) {
    const url = `${this.apiUrl}/annotations`;
    delete annotation.id;
    return this.http.post<Annotation>(url, annotation);
  }

  updateAnnotation(annotation: Annotation) {
    const url = `${this.apiUrl}/annotations/${annotation.id}`;
    return this.http.put<Annotation>(url, annotation);
  }

  deleteAnnotation(id: string) {
    const url = `${this.apiUrl}/annotations/${id}`;
    return this.http.delete<Annotation>(url);
  }
}
