import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Book } from '../book';
import { BooksService } from '../books.service';

@Component({
  selector: 'app-add-book',
  templateUrl: './add-book.component.html',
  styleUrls: ['./add-book.component.css']
})
export class AddBookComponent implements OnInit {

  book: Book;

  constructor(private booksService: BooksService, private route: ActivatedRoute, private router: Router) { }

  ngOnInit(): void {
    this.book = new Book();
  }

  addBook()
  {
    this.booksService.create(this.book)
      .subscribe(data => { this.book = data; this.router.navigate(['/books']); }, error => { console.log(error) });
  }

}
