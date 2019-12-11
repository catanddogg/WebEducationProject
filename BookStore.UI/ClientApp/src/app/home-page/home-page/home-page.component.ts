import { Component, OnInit, Input, EventEmitter } from '@angular/core';
import { Router } from '@angular/router';
import { HttpService } from 'src/app/shared/services/http.service';
import { GetBookById } from 'src/app/shared/model/get-book.view';
import { SignalrService } from 'src/app/shared/services/signalr.service';

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.scss']
})

export class HomePageComponent implements OnInit {


  constructor(private router: Router) {
  }

  ngOnInit() {
    // this.router.navigate(['/Books']);
  }
}