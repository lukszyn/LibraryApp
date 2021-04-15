import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Book } from '../book';
import { BooksService } from '../books.service';

@Component({
  selector: 'app-edit-book',
  templateUrl: './edit-book.component.html',
  styleUrls: ['./edit-book.component.css']
})

export class EditBookComponent implements OnInit {

  book: Book;

  constructor(private booksService: BooksService, private route: ActivatedRoute, private router: Router) { }

  ngOnInit(): void {
    this.retrieveBook(this.route.snapshot.params.id);
  }

  retrieveBook(id: any) {
    this.booksService.get(id)
      .subscribe(data => { this.book = data; console.log(data) }, error => { console.log(error) });
  }

  editBook(id: any)
  {
    this.booksService.update(id, this.book)
      .subscribe(data => { this.book = data; this.router.navigate(['/books']); }, error => { console.log(error) });
  }
}
