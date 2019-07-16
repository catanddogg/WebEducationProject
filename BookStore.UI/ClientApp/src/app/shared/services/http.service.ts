import { Injectable } from "@angular/core";
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { GetBookById } from 'src/app/shared/model/GetBook';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})

export class HttpService {

  private baseUrl = environment.baseUrl;
  bookById: GetBookById;

  constructor(private http: HttpClient) { }

  public Test(): Observable<GetBookById> {
    var test = this.http.get<GetBookById>(this.baseUrl + 'api/books/5');
    return test;
  }
}
