import { Component, OnInit, Input } from '@angular/core';
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
  @Input() userName:string;

  constructor(private router: Router, private httpService: HttpService)
  {
     this.arrayBook = [];
  }

  ngOnInit() {
    this.test('');
  } 

  public test(model: string) {
    this.userName = model;
    this.httpService.GetSearchForBookLibary(this.userName)
      .subscribe(
        response => {
          this.arrayBook = response.books;
        });
  }

  public nextPage(){
    this.router.navigate(['/']);
  }
}