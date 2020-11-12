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
import { SendEmailToResetPasswordViewModel } from '../model/send-email-reset-password.view';
import { ResetPasswordViewModel } from '../model/reset-password';
import { BookViewModel } from '../model/book.view';
import { NotificationsByUserIdView } from '../model/notifications-by-user-id.view';
import { CreateNotificationRequestView } from '../model/create-notification-request.view';
import { CreateNotificationResponseView } from '../model/create-notification-response.view';

@Injectable({
  providedIn: 'root'
})

export class HttpService {

  private baseUrl : string;

  constructor(private http: HttpClient) { 
    this.baseUrl = environment.baseUrl;
  }
 
  public CreateNotification(model: CreateNotificationRequestView): Observable<CreateNotificationResponseView>{
    let response = this.http.post<CreateNotificationResponseView>(`${this.baseUrl}api/notification/CreateNotification`, model);

    return response;
  }

  public GetNotificationsByUserId(userId: string): Observable<NotificationsByUserIdView>{
    let response = this.http.get<NotificationsByUserIdView>(`${this.baseUrl}api/notification/NotificationsByUserId?userId=${userId}`);

    return response;
  }

  public GetSearchForBookLibary(model : string): Observable<AllBookViewModel> {
    let response = this.http.get<AllBookViewModel>(`${this.baseUrl}api/books/GetAllBook?filter=${model}`);

    return response;
  }

  public GetBookById(bookId: number):Observable<BookViewModel>{
    let response = this.http.get<BookViewModel>(`${this.baseUrl}api/books/GetBookById?bookId=${bookId}`);

    return response;
  }

  public CreateUser (model : CreateUserViewModel) : Observable<BaseResponseViewModel> {
    let response = this.http.post<BaseResponseViewModel>(`${this.baseUrl}${'api/Person/CreateUser'}`, model);

    return  response;
  }

  public LogInUser(model : LoginUserViewModel) : Observable<LoginUserRequestViewModel> {
    let response = this.http.post<LoginUserRequestViewModel>(`${this.baseUrl}${'api/Person/Login'}`, model);

    return response;
  }

  public RefreshToken(model : RefreshTokenViewModel) : Observable<LoginUserRequestViewModel> {
    let response = this.http.post<LoginUserRequestViewModel>(`${this.baseUrl}${'api/Person/RefreshToken'}`, model);
    
    return response;
  }

  public SendEmailToRecoverPassword(model : SendEmailToResetPasswordViewModel): Observable<BaseResponseViewModel> {
    let response = this.http.post<BaseResponseViewModel>(`${this.baseUrl}${'api/Person/SendEmailToRecoverPassword'}`, model);

    return response;
  }

  public ResetPassword(model : ResetPasswordViewModel): Observable<BaseResponseViewModel>{
    let response = this.http.post<BaseResponseViewModel>(`${this.baseUrl}${'api/Person/ResetPassword'}`, model);

    return response;
  }

  public CreateBook(model: BookViewModel): Observable<BaseResponseViewModel>{
    let response = this.http.post<BaseResponseViewModel>(`${this.baseUrl}${'api/Books/CreateBook'}`, model);

    return response;
  }

  public UpdateBook(model: BookViewModel): Observable<BaseResponseViewModel>{
    let response = this.http.post<BaseResponseViewModel>(`${this.baseUrl}${'api/Books/UpdateBook'}`, model);

    return response;    
  }
}
