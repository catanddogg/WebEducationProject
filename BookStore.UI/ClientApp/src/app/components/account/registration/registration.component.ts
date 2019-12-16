import { Component, OnInit } from '@angular/core';
import { CreateUserViewModel } from 'src/app/shared/model/create-user.model';
import { Router } from '@angular/router';
import { HttpService } from 'src/app/shared/services/http.service';
import { NotificationService } from 'src/app/shared/services/toastr.service';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.scss']
})
export class RegistrationComponent implements OnInit {
  
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
          this.router.navigate(['/Account']);
         }
         if(response.success == false)
         {
          this.notificationService.NotificationError(response.message);
         }
        });
  }
  
  public navigationToSingInPage()
  {
    this.router.navigate(['/Account']);
  }

  public navigationToForgotPassword()
  {
    this.router.navigate(['/Account/ForgotPassword']);
  }
}
