import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Book } from './book';

const booksURL = "http://localhost:10500/api/books";

@Injectable({
  providedIn: 'root'
})

export class BooksService {

  constructor(private http: HttpClient) { }

  getAll(): Observable<Book[]>
  {
    return this.http.get<Book[]>(booksURL);
  }

  get(id: any): Observable<Book>
  {
    return this.http.get<Book>(`${booksURL}/${id}`);
  }

  create(book: Book): Observable<any>
  {
    return this.http.post(booksURL, book);
  }

  update(id:any, book: Book): Observable<any>
  {
    return this.http.put(`${booksURL}/${id}`, book);
  }

  delete(id: any): Observable<any>
  {
    return this.http.delete(`${booksURL}/${id}`);
  }
}
