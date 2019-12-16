import { Component, OnInit } from '@angular/core';
import { ResetPasswordViewModel } from 'src/app/shared/model/reset-password';
import { ActivatedRoute, Router } from '@angular/router';
import { HttpService } from 'src/app/shared/services/http.service';
import { NotificationService } from 'src/app/shared/services/toastr.service';

@Component({
  selector: 'app-recover-password',
  templateUrl: './recover-password.component.html',
  styleUrls: ['./recover-password.component.scss']
})
export class RecoverPasswordComponent implements OnInit {

  private resetPasswordViewModel : ResetPasswordViewModel;

  constructor(private activateRoute: ActivatedRoute,
     private http: HttpService,
     private toastr: NotificationService,
     private router: Router) {   
       this.resetPasswordViewModel =  new ResetPasswordViewModel();
  }

  ngOnInit() {
  }

  public recoverPassword(){
    this.resetPasswordViewModel.ResetPasswordToken = this.activateRoute.snapshot.params['id'].substring(3);
    
    this.http.ResetPassword(this.resetPasswordViewModel)
    .subscribe(data => {
      if(data.success){
        this.toastr.NotificationSuccess(data.message);
        this.router.navigate(['/Account']);
      }
      if(!data.success){
        this.toastr.NotificationError(data.message);
      }
    });
  }
}
