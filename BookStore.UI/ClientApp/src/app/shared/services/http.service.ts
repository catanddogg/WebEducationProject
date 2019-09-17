import { Injectable } from "@angular/core";
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { AllBookViewModel } from 'src/app/shared/model/get-all-book.view';
import { Observable } from 'rxjs';
import { CreateUserViewModel } from 'src/app/shared/model/create-user.model';

@Injectable({
  providedIn: 'root'
})

export class HttpService {

  private baseUrl = environment.baseUrl;
  private fullApiUrl : string;
  private _http : HttpClient;

  constructor(private http: HttpClient) { 
    this._http = http;
  }

  public Test(model : string): Observable<AllBookViewModel> {
    this.fullApiUrl = `${this.baseUrl}${'api/books/GetAllBook?filter='}${model}`;

    return this._http.get<AllBookViewModel>(this.fullApiUrl);
  }

  // public CreateUser (model : CreateUserViewModel) : Observable<string> {
  //   this.fullApiUrl = `${this.baseUrl}${'api/Person/CreateUser'}`;

  //   // const body = {userName: model.UserName, confirmPassword : model.ConfirmPassword, password : model.Password, email : model.Email};

  //   let test = this.http.post<string>(this.fullApiUrl, model);
  //   debugger;
  //   return  test;
  // }

  public CreateUser(model : CreateUserViewModel): Observable<string> {
    //this.fullApiUrl = `${this.baseUrl}${'api/books/CreateUser?userName='}${model.userName}${'&password='}${model.password}${'&confirmPassword='}${model.confirmPassword}${'&email='}${model.email}`;

    let model1 = "test";
    let test = `${this.baseUrl}${'api/books/GetAllBook?filter='}${model1}`;

    this.fullApiUrl = `${this.baseUrl}${'api/Person/CreateUser'}`;
    //var test1 = this._http.get<string>(this.fullApiUrl);
    let test1 = this.http.post<string>(this.fullApiUrl, model);
    debugger;

    return test1;
  }
}
