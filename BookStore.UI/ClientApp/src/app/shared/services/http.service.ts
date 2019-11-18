import { Injectable } from "@angular/core";
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { AllBookViewModel } from 'src/app/shared/model/get-all-book.view';
import { Observable } from 'rxjs';
import { CreateUserViewModel } from 'src/app/shared/model/create-user.model';
import { BaseResponseViewModel } from 'src/app/shared/model/base-response.view';
import { LoginUserViewModel } from 'src/app/shared/model/login-user';
import { LoginUserRequestViewModel } from 'src/app/shared/model/login-user-request.view';

@Injectable({
  providedIn: 'root'
})

export class HttpService {

  private baseUrl = environment.baseUrl;
  private fullApiUrl : string;

  constructor(private http: HttpClient) { 
  }
 
  public Test(model : string): Observable<AllBookViewModel> {
    this.fullApiUrl = `${this.baseUrl}${'api/books/GetAllBook?filter='}${model}`;

    return this.http.get<AllBookViewModel>(this.fullApiUrl);
  }

  public CreateUser (model : CreateUserViewModel) : Observable<BaseResponseViewModel> {
    this.fullApiUrl = `${this.baseUrl}${'api/Person/CreateUser'}`;
    let response = this.http.post<BaseResponseViewModel>(this.fullApiUrl, model);

    return  response;
  }

  public LogInUser(model : LoginUserViewModel) : Observable<LoginUserRequestViewModel> {
    this.fullApiUrl = `${this.baseUrl}${'api/Person/Login'}`;
    let response = this.http.post<LoginUserRequestViewModel>(this.fullApiUrl, model);
    debugger;
    return  response;
  }
}
