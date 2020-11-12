import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AccountComponent } from './account.component';
import { LoginComponent } from './login/login.component';
import { RegistrationComponent } from './registration/registration.component';
import { ForgotPasswordComponent } from './forgot-password/forgot-password.component';
import { RecoverPasswordComponent } from './recover-password/recover-password.component';

const routes: Routes = [
  {
    path: '', component: AccountComponent, children: [
         { path: '', component: LoginComponent },
         { path: 'SingUp', component: RegistrationComponent },
         { path: 'ForgotPassword', component: ForgotPasswordComponent },
         { path: 'ResetPassword/:id', component: RecoverPasswordComponent }
    ],
  }
]

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})

export class AccountRoutingModule { }
