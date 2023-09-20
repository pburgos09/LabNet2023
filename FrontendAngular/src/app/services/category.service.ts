import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Category, NewCategory } from '../interfaces/category.interface';
import { Observable, catchError, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class CategoryService {
  API_URL = 'https://localhost:44300/api/Categories';
  headers = new HttpHeaders({ 'Content-Type': 'application/json' });
  constructor(private http: HttpClient) {}

  getCategories() {
    return this.http.get<Category[]>(`${this.API_URL}`, {
      headers: this.headers,
    });
  }

  deleteCategory(id: number): Observable<void> {
    return this.http
      .delete<void>(`${this.API_URL}/${id}`, {
        headers: this.headers,
      })
      .pipe(
        catchError((error) => {
          console.error('Error en la eliminacion:', error);
          return throwError(error);
        })
      );
  }

  addCategory(category: NewCategory) {
    return this.http
      .post(`${this.API_URL}`, category, {
        headers: this.headers,
      })
      .pipe(
        catchError((error) => {
          console.error('Error en la creacion:', error);
          return throwError(error);
        })
      );
  }

  updateCategory(category: Category) {
    return this.http
      .put(`${this.API_URL}/${category.CategoryID}`, category, {
        headers: this.headers,
      })
      .pipe(
        catchError((error) => {
          console.error('Error en la actualizacion:', error);
          return throwError(error);
        })
      );
  }

  getCategoryById(id: number) {
    return this.http
      .get<Category>(`${this.API_URL}/${id}`, {
        headers: this.headers,
      })
      .pipe(
        catchError((error) => {
          console.error('Error en la obtención:', error);
          return throwError(error);
        })
      );
  }
}
