import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { HttpService } from 'src/app/shared/services/http.service';

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.scss']
})
export class HomePageComponent implements OnInit {

  constructor(private router: Router, private httpService: HttpService) { }

  ngOnInit() {
  }

  public test() {
    this.httpService.Test()
      .subscribe(
        response => {
          //this.bookById = response;
        });
  }

  public nextPage(){
    this.router.navigate(['/home-page']);
  }
}