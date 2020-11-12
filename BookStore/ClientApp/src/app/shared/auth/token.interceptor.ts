import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { AuthService } from 'src/app/shared/services/auth.service';
import { Observable } from 'rxjs';

@Injectable({providedIn: "root"})

export class TokenInterceptor implements HttpInterceptor {
  constructor(public auth: AuthService) {}
  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    
    request = request.clone({
      setHeaders: {
        Authorization: `Bearer ${localStorage.getItem('AccessToken')}`
      }
    });
    return next.handle(request);
  }
}