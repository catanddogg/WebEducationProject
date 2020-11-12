import { Injectable } from '@angular/core';
import { Router, CanActivate } from '@angular/router';
import { AuthService } from './auth.service';
import { HttpService } from './http.service';
import { RefreshTokenViewModel } from '../model/refresh-token.view';
import { getLocaleDayNames } from '@angular/common';
import { LoginUserViewModel } from '../model/login-user';

@Injectable({providedIn: "root"})

export class AuthGuardService implements CanActivate {
  constructor(private auth: AuthService,
     private router: Router,
     private http: HttpService) {
  }
  
  canActivate(): boolean {
    if (!this.auth.isAuthenticated()) {
      let refreshToken = localStorage.getItem('RefreshToken');
 
      if(refreshToken)
      {
        let model =  new RefreshTokenViewModel()
        model.RefreshToken = refreshToken;

        this.http.RefreshToken(model)
        .subscribe( response =>{
          if(response.success){
            localStorage.setItem("AccessToken", response.accessToken);
            localStorage.setItem("RefreshToken", response.refreshToken);
          }   
          if(!response.success){
            this.router.navigate(['']);
          }      
        });
        return true;
      }
      this.router.navigate(['']);
      return false;
    }
    return true;
  }
}