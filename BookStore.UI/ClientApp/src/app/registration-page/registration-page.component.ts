import { Component, OnInit } from '@angular/core';
import { CreateUserViewModel } from 'src/app/shared/model/create-user.model';
import { HttpService } from 'src/app/shared/services/http.service';
import { NotificationService } from 'src/app/shared/services/toastr.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-registration-page',
  templateUrl: './registration-page.component.html',
  styleUrls: ['./registration-page.component.scss']
})
export class RegistrationPageComponent implements OnInit {

  private _createUser : CreateUserViewModel;

  constructor(private router: Router, private httpService: HttpService, private notificationService : NotificationService ) { 
    this._createUser = new CreateUserViewModel();
  }

  ngOnInit() {
  }
  
  public navigationToSingInPage()
  {
    debugger;
    this.router.navigate(['/']);
  }

  public SingUpUser(userName : string, password : string, confirmPassword : string, email : string) {
       this._createUser.userName = userName;
       this._createUser.password = password;
       this._createUser.confirmPassword = confirmPassword;
       this._createUser.email = email;

       this.httpService.CreateUser(this._createUser)
       .subscribe(response => {
         if(response.success == true)
         {
          this.router.navigate(['/']);
         }
         if(response.success == false)
         {
          this.notificationService.NotificationError(response.message);
         }
        });
  }
}
