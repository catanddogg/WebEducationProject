import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { HttpService } from '../shared/services/http.service';
import { NotificationService } from '../shared/services/toastr.service';
import { SendEmailToResetPasswordViewModel } from '../shared/model/send-email-reset-password.view';

@Component({
  selector: 'app-forgot-password',
  templateUrl: './forgot-password.component.html',
  styleUrls: ['./forgot-password.component.scss']
})
export class ForgotPasswordComponent implements OnInit {

  constructor(private router: Router, 
    private http: HttpService,
    private toastr: NotificationService) {

   }

  ngOnInit() {
  } 
  
  public SendMailToRecoverPassword(email : string){

    var model =  new SendEmailToResetPasswordViewModel();
    model.PersonEmail = email;

    this.http.SendEmailToRecoverPassword(model)
    .subscribe(data => {
      if(data.success)
      {
        this.toastr.NotificationSuccess(data.message);
        this.router.navigate(['']);
      }
      if(!data.success)
      {
        this.toastr.NotificationError(data.message);
      }
    });
  }

  public NavigationToSingUp(){
    this.router.navigate(['/SingUp']);
 }

 public NavigationToSignIn(){
  this.router.navigate(['/']);
 }
}
