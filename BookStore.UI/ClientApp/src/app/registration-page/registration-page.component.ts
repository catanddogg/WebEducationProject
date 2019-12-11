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

  private createUser : CreateUserViewModel;

  constructor(private router: Router, 
    private httpService: HttpService,
    private notificationService : NotificationService) { 
    this.createUser = new CreateUserViewModel();
  }

  ngOnInit() {
  }  
  
  public singUpUser() {    
       this.httpService.CreateUser(this.createUser)
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
  
  public navigationToSingInPage()
  {
    this.router.navigate(['/']);
  }

  public navigationToForgotPassword()
  {
    this.router.navigate(['/ForgotPassword']);
  }
}