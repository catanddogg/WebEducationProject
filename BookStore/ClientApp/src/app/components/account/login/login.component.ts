import { Component, OnInit } from '@angular/core';
import { LoginUserViewModel } from 'src/app/shared/model/login-user';
import { Router } from '@angular/router';
import { HttpService } from 'src/app/shared/services/http.service';
import { NotificationService } from 'src/app/shared/services/toastr.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  private loginUserViewModel : LoginUserViewModel;

  constructor(private router : Router, 
              private httpService: HttpService,
              private notificationService : NotificationService) {
    this.loginUserViewModel = new LoginUserViewModel();
  }

  ngOnInit() {
  }

  public logIn(){
    this.httpService.LogInUser(this.loginUserViewModel)
    .subscribe(response => {
      if(response.success)
      {
        localStorage.setItem("AccessToken", response.accessToken);
        localStorage.setItem("RefreshToken", response.refreshToken);
        localStorage.setItem("UserName", response.userName);
        localStorage.setItem("UserId", response.userId);

        this.router.navigate(['/Storage/Books']);
      }
      if(!response.success)
      {
        this.notificationService.NotificationError(response.message);
      }
    });
  }

  public navigationToSingUpPage(){
       this.router.navigate(['/Account/SingUp']);
  }

  public navigationToForgotPassword(){
    this.router.navigate(['/Account/ForgotPassword']);
  }
}
