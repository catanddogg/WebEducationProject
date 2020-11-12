import { Component, OnInit } from '@angular/core';
import { SendEmailToResetPasswordViewModel } from 'src/app/shared/model/send-email-reset-password.view';
import { Router } from '@angular/router';
import { HttpService } from 'src/app/shared/services/http.service';
import { NotificationService } from 'src/app/shared/services/toastr.service';

@Component({
  selector: 'app-forgot-password',
  templateUrl: './forgot-password.component.html',
  styleUrls: ['./forgot-password.component.scss']
})
export class ForgotPasswordComponent implements OnInit {

  private sendMailModel: SendEmailToResetPasswordViewModel;

  constructor(private router: Router,
    private http: HttpService,
    private toastr: NotificationService) {
    this.sendMailModel = new SendEmailToResetPasswordViewModel();
  }

  ngOnInit() {
  }

  public sendMailToRecoverPassword() {
    this.http.SendEmailToRecoverPassword(this.sendMailModel)
      .subscribe(data => {
        if (data.success) {
          this.toastr.NotificationSuccess(data.message);
          this.router.navigate(['/Account']);
        }
        if (!data.success) {
          this.toastr.NotificationError(data.message);
        }
      });
  }

  public navigationToSingUp() {
    this.router.navigate(['/Account/SingUp']);
  }

  public navigationToSignIn() {
    this.router.navigate(['/Account/']);
  }
}
