import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { HttpService } from 'src/app/shared/services/http.service';
import { GetBookById} from 'src/app/shared/model/get-book.view';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.scss']
})
export class HomePageComponent implements OnInit {


  public arrayBook : GetBookById [];


  constructor(private router: Router, private httpService: HttpService)
  {
     this.arrayBook = [];
  }

  ngOnInit() {
  } 

  public test() {
    this.httpService.Test()
      .subscribe(
        response => {
          this.arrayBook = response.books;
          debugger;
        });
  }

  public nextPage(){
    this.router.navigate(['/home-page']);
  }
}