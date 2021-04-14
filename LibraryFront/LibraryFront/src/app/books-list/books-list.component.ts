import { Component, OnInit } from '@angular/core';
import { Book } from '../book';
import { BooksService } from '../books.service';

@Component({
  selector: 'app-books-list',
  templateUrl: './books-list.component.html',
  styleUrls: ['./books-list.component.css']
})
export class BooksListComponent implements OnInit {

  books: Book[];
  constructor(private booksService: BooksService) { }

  ngOnInit(): void {

    var book = new Book();

    this.retrieveBooks();
  }

  retrieveBooks() {
    this.booksService.getAll()
      .subscribe(data => { this.books = data; console.log(data) }, error => { console.log(error) });
  }

  addBook(book: Book)
  {
    this.booksService.create(book)
    .subscribe(response => {console.log(response); this.retrieveBooks()},
    error => console.log(error));
  }

  deleteBook(id: number)
  {
    this.booksService.delete(id)
    .subscribe(response => {console.log(response); this.retrieveBooks()},
    error => console.log(error));
  }

}
