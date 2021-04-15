import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Book } from '../book';
import { BooksService } from '../books.service';

@Component({
  selector: 'app-book-details',
  templateUrl: './book-details.component.html',
  styleUrls: ['./book-details.component.css']
})
export class BookDetailsComponent implements OnInit {

  book: Book;

  constructor(private booksService: BooksService, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.retrieveBook(this.route.snapshot.params.id);
  }

  retrieveBook(id: any) {
    this.booksService.get(id)
      .subscribe(data => { this.book = data; console.log(data) }, error => { console.log(error) });
  }

  borrowBook(id: any) {
    this.book.isBorrowed = true;
    this.booksService.update(id, this.book)
      .subscribe(data => { this.book = data; this.retrieveBook(id) }, error => { console.log(error) });
  }

  returnBook(id: any) {
    this.book.isBorrowed = false;
    this.booksService.update(id, this.book)
      .subscribe(data => { this.book = data; this.retrieveBook(id) }, error => { console.log(error) });
  }
}
