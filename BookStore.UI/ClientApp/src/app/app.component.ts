import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { HttpService } from 'src/app/shared/services/http.service';
import { GetBookById } from 'src/app/shared/model/get-book.view';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'ClientApp';
  bookById: GetBookById;

  constructor(private router: Router, private httpService: HttpService) {
  }  
}
