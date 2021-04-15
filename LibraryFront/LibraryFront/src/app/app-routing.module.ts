import { BookDetailsComponent } from './book-details/book-details.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { BooksListComponent } from './books-list/books-list.component';
import { EditBookComponent } from './edit-book/edit-book.component';
import { AddBookComponent } from './add-book/add-book.component';

const routes: Routes = [{ path: "", redirectTo: "books", pathMatch: "full" },
{ path: "books/add", component: AddBookComponent },
{ path: "books", component: BooksListComponent },
{ path: "books/:id", component: BookDetailsComponent },
{ path: "books/edit/:id", component: EditBookComponent },
]

@NgModule({
  imports: [RouterModule.forRoot(routes, {onSameUrlNavigation: 'reload'})],
  exports: [RouterModule]
})
export class AppRoutingModule { }
