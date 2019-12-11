import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { Router, RouterModule, Routes, CanActivate } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { HomePageComponent } from './home-page/home-page/home-page.component';
import { LoginPageComponent } from './login-page/login-page.component';
import { RegistrationPageComponent } from './registration-page/registration-page.component';
import { ToastrModule } from 'ngx-toastr';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AuthGuardService as AuthGuard } from './shared/services/auth-guard.service';
import { JwtModule } from "@auth0/angular-jwt";
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { TokenInterceptor } from 'src/app/shared/auth/token.interceptor';
import { ForgotPasswordComponent } from './forgot-password/forgot-password.component';
import { RecoverPasswordComponent } from './recover-password/recover-password.component';
import { BookItemComponent } from './book-item/book-item.component';
import { FormsModule } from '@angular/forms';
import { MatSliderModule } from '@angular/material/slider';
import { ChatComponent } from './chat/chat.component';
import { SidebarComponent } from './shared/component/sidebar/sidebar.component';
import { FooterComponent } from './shared/component/footer/footer.component';
import { BookListComponent } from './book-list/book-list.component';

const routes: Routes = [
  { path: '', component: LoginPageComponent },
  { path: 'Home', loadChildren: () => import('./home-page/home-page.module').then(module => module.HomePageModule), canActivate: [AuthGuard] },
  { path: 'SingUp', component: RegistrationPageComponent },
  { path: 'ForgotPassword', component: ForgotPasswordComponent },
  { path: 'ResetPassword/:id', component: RecoverPasswordComponent },
  { path: 'Book/:id', component: BookItemComponent, canActivate: [AuthGuard]},
  { path: 'Chat', component: ChatComponent, canActivate: [AuthGuard]},
  { path: 'Books', component: BookListComponent, canActivate: [AuthGuard]},
  { path: '**', redirectTo: '' }
];

@NgModule({
  declarations: [
    AppComponent,
    HomePageComponent,
    LoginPageComponent,
    RegistrationPageComponent,
    ForgotPasswordComponent,
    RecoverPasswordComponent,
    BookItemComponent,
    ChatComponent,
    SidebarComponent,
    FooterComponent,
    BookListComponent
  ],  
  imports: [
    BrowserModule,  
    RouterModule.forRoot(routes),
    FormsModule, 
    HttpClientModule,
    MatSliderModule,
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