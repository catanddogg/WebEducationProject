import { Injectable } from "@angular/core";
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { AllBookViewModel } from 'src/app/shared/model/get-all-book.view';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})

export class HttpService {

  private baseUrl = environment.baseUrl;
  public allbook: AllBookViewModel;
  public fullApiUrl : string;

  constructor(private http: HttpClient) { }

  public Test(model : string): Observable<AllBookViewModel> {
    this.fullApiUrl = `${this.baseUrl}${'api/books/GetAllBook?filter='}${model}`;

    return this.http.get<AllBookViewModel>(this.fullApiUrl);
  }
}
