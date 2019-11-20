import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { Router, RouterModule, Routes, CanActivate } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { HomePageComponent } from './home-page/home-page/home-page.component';
import { LoginPageComponent } from './login-page/login-page.component';
import { RegistrationPageComponent } from './registration-page/registration-page.component';
import { ToastrModule } from 'ngx-toastr';
import { AuthService } from './shared/services/auth.service';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AuthGuardService as AuthGuard } from './shared/services/auth-guard.service';
import { JwtModule } from "@auth0/angular-jwt";
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { TokenInterceptor } from 'src/app/shared/auth/token.interceptor';
import { ForgotPasswordComponent } from './forgot-password/forgot-password.component';
import { RecoverPasswordComponent } from './recover-password/recover-password.component';

const routes: Routes = [
  { path: '', component: LoginPageComponent },
  { path: 'Home', component: HomePageComponent, canActivate: [AuthGuard] },
  { path: 'SingUp', component: RegistrationPageComponent },
  { path: 'ForgotPassword', component: ForgotPasswordComponent },
  { path: 'ResetPassword/:id', component: RecoverPasswordComponent },
  { path: '**', redirectTo: '' }
];

@NgModule({
  declarations: [
    AppComponent,
    HomePageComponent,
    LoginPageComponent,
    RegistrationPageComponent,
    ForgotPasswordComponent,
    RecoverPasswordComponent
  ],  
  imports: [
    BrowserModule,  
    RouterModule.forRoot(routes),
    HttpClientModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot(),
    JwtModule.forRoot({ config: {} })  
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: TokenInterceptor,
      multi: true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
