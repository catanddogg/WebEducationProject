import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { HttpService } from 'src/app/shared/services/http.service';
import { LoginUserViewModel } from 'src/app/shared/model/login-user';
import { NotificationService } from 'src/app/shared/services/toastr.service';


@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.scss']
})

export class LoginPageComponent implements OnInit {

  private _loginUserViewModel : LoginUserViewModel;

  constructor(private router : Router, 
              private httpService: HttpService,
              private notificationService : NotificationService) {
    this._loginUserViewModel = new LoginUserViewModel();
  }

  ngOnInit() {
  }

  public LogIn(userName : string, password : string){
    this._loginUserViewModel.password = password;
    this._loginUserViewModel.userName = userName;

    this.httpService.LogInUser(this._loginUserViewModel)
    .subscribe(response => {
      if(response.success)
      {
        localStorage.setItem("AccessToken", response.accessToken);
        localStorage.setItem("RefreshToken", response.refreshToken);

        this.router.navigate(['/Home']);
      }
      if(!response.success)
      {
        this.notificationService.NotificationError(response.message);
      }
    });
  }

  public navigationToSingUpPage(){
       this.router.navigate(['/SingUp']);
  }
}
