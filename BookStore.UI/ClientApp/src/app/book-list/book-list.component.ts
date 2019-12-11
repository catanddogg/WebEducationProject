import { Component, OnInit } from '@angular/core';
import { GetBookById } from '../shared/model/get-book.view';
import { Router } from '@angular/router';
import { HttpService } from '../shared/services/http.service';

@Component({
  selector: 'app-book-list',
  templateUrl: './book-list.component.html',
  styleUrls: ['./book-list.component.scss']
})
export class BookListComponent implements OnInit {

 
  private arrayBook: GetBookById[];
  private userName: string;

  constructor(private router: Router,
     private httpService: HttpService) {
    this.userName = '';
    this.arrayBook = [];
  }

  ngOnInit() {
    this.booksSearch();
  }

  booksSearch() {
    this.httpService.GetSearchForBookLibary(this.userName)
      .subscribe(
        response => {
          this.arrayBook = response.books;
        });
  }

  navigateToBookItem(id: number) {
    this.router.navigate(['/Book', id]);
  }

  addNewBook() {
    this.router.navigate(['/Book', 0]);
  }

  navigationToChat(){
    this.router.navigate(['/Chat']);
  }
}
