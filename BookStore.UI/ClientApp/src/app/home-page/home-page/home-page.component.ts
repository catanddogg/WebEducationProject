import { Component, OnInit, Input, EventEmitter } from '@angular/core';
import { Router } from '@angular/router';
import { HttpService } from 'src/app/shared/services/http.service';
import { GetBookById } from 'src/app/shared/model/get-book.view';
import { HubConnection, HubConnectionBuilder } from '@aspnet/signalr';
import * as signalR from '@aspnet/signalr';

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.scss']
})
export class HomePageComponent implements OnInit {

  private arrayBook: GetBookById[];
  private userName: string;
  private connection: HubConnection;
  private thenable: Promise<void>


  private connectionIsEstablished  = false;

  constructor(private router: Router, private httpService: HttpService) {
    this.userName = '';
    this.arrayBook = [];
  }

  ngOnInit() {
    this.connection = new HubConnectionBuilder().withUrl("https://localhost:44357/chat", {
      skipNegotiation: true,
      transport: signalR.HttpTransportType.WebSockets
    }).build();

    this.start();
       
    this.BooksSearch();
  }

  private start() {
    this.thenable = this.connection.start();
  }

  BooksSearch() {
    this.httpService.GetSearchForBookLibary(this.userName)
      .subscribe(
        response => {
          this.arrayBook = response.books;
        });
  }

  NavigateToBookItem(id: number) {
    this.router.navigate(['/Book', id]);
  }

  AddNewBook() {
    this.router.navigate(['/Book', 0]);
  }
  TestSignalR() {
      this.connection.invoke('Send', "test");
  }
}