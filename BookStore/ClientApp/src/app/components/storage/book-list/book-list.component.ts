import { Component, OnInit } from '@angular/core';
import { GetBookById } from 'src/app/shared/model/get-book.view';
import { Router } from '@angular/router';
import { HttpService } from 'src/app/shared/services/http.service';
import { createChart } from 'lightweight-charts';

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
    const chart = createChart(document.body, { width: 400, height: 300 });
    const lineSeries = chart.addLineSeries();
    lineSeries.setData([
        { time: '2019-04-11', value: 80.01 },
        { time: '2019-04-12', value: 96.63 },
        { time: '2019-04-13', value: 76.64 },
        { time: '2019-04-14', value: 81.89 },
        { time: '2019-04-15', value: 74.43 },
        { time: '2019-04-16', value: 80.01 },
        { time: '2019-04-17', value: 96.63 },
        { time: '2019-04-18', value: 76.64 },
        { time: '2019-04-19', value: 81.89 },
        { time: '2019-04-20', value: 74.43 },
    ]);
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
    this.router.navigate(['/Storage/Book', id]);
  }

  addNewBook() {
    this.router.navigate(['/Storage/Book', 0]);
  }

  navigationToChat(){
    this.router.navigate(['/Storage/Chat']);
  }

}
