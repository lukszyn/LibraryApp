import { BookDetailsComponent } from './book-details/book-details.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { BooksListComponent } from './books-list/books-list.component';

const routes: Routes = [{ path: "", redirectTo: "books", pathMatch: "full" },
{ path: "books", component: BooksListComponent },
{ path: "books/:id", component: BookDetailsComponent }
]

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
