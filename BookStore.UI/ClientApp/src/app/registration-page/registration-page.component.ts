import { Component, OnInit } from '@angular/core';
import { CreateUserViewModel } from 'src/app/shared/model/create-user.model';
import { HttpService } from 'src/app/shared/services/http.service';

@Component({
  selector: 'app-registration-page',
  templateUrl: './registration-page.component.html',
  styleUrls: ['./registration-page.component.scss']
})
export class RegistrationPageComponent implements OnInit {

  public createUser : CreateUserViewModel;

  constructor(private httpService: HttpService) { 
    this.createUser = new CreateUserViewModel();
  }

  ngOnInit() {
  }

  
  public SingUpUser(userName : string, password : string, confirmPassword : string, email : string) {
       this.createUser.userName = userName;
       this.createUser.password = password;
       this.createUser.confirmPassword = confirmPassword;
       this.createUser.email = email;

       this.httpService.CreateUser(this.createUser)
       .subscribe(response => {
        });;
  }
}
