import { Injectable } from "@angular/core";
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { AllBookViewModel } from 'src/app/shared/model/get-all-book.view';
import { Observable } from 'rxjs';
import { CreateUserViewModel } from 'src/app/shared/model/create-user.model';
import { BaseResponseViewModel } from 'src/app/shared/model/base-response.view';
import { LoginUserViewModel } from 'src/app/shared/model/login-user';
import { LoginUserRequestViewModel } from 'src/app/shared/model/login-user-request.view';
import { RefreshTokenViewModel } from '../model/refresh-token.view';

@Injectable({
  providedIn: 'root'
})

export class HttpService {

  private baseUrl : string;
  private fullApiUrl : string;

  constructor(private http: HttpClient) { 
    this.baseUrl = environment.baseUrl;
  }
 
  public Test(model : string): Observable<AllBookViewModel> {
    this.fullApiUrl = `${this.baseUrl}api/books/GetAllBook?filter=${model}`;
    let response = this.http.get<AllBookViewModel>(this.fullApiUrl);

    return response;
  }

  public CreateUser (model : CreateUserViewModel) : Observable<BaseResponseViewModel> {
    this.fullApiUrl = `${this.baseUrl}${'api/Person/CreateUser'}`;
    let response = this.http.post<BaseResponseViewModel>(this.fullApiUrl, model);

    return  response;
  }

  public LogInUser(model : LoginUserViewModel) : Observable<LoginUserRequestViewModel> {
    this.fullApiUrl = `${this.baseUrl}${'api/Person/Login'}`;
    let response = this.http.post<LoginUserRequestViewModel>(this.fullApiUrl, model);

    return response;
  }

  public RefreshToken(model : RefreshTokenViewModel) : Observable<LoginUserRequestViewModel> {
    this.fullApiUrl = `${this.baseUrl}${'api/Person/RefreshToken'}`;
    let response = this.http.post<LoginUserRequestViewModel>(this.fullApiUrl, model);
    
    return response;
  }
}
