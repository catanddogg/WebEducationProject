import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ResetPasswordViewModel } from '../shared/model/reset-password';
import { HttpService } from '../shared/services/http.service';
import { NotificationService } from '../shared/services/toastr.service';

@Component({
  selector: 'app-recover-password',
  templateUrl: './recover-password.component.html',
  styleUrls: ['./recover-password.component.scss']
})
export class RecoverPasswordComponent implements OnInit {

  constructor(private activateRoute: ActivatedRoute,
     private http: HttpService,
     private toastr: NotificationService,
     private router: Router) {   
  }

  ngOnInit() {
  }

  public RecoverPassword(password: string, confirmPassword: string){
    var model = new ResetPasswordViewModel();
    model.Password = password;
    model.ConfirmPassword = confirmPassword;
    model.ResetPasswordToken = this.activateRoute.snapshot.params['id'].substring(3);
    
    this.http.ResetPassword(model)
    .subscribe(data => {
      if(data.success){
        this.toastr.NotificationSuccess(data.message);
        this.router.navigate(['']);
      }
      if(!data.success){
        this.toastr.NotificationError(data.message);
      }
    });
  }
}
