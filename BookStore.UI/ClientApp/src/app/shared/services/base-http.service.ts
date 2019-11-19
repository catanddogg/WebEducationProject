import { Injectable } from "@angular/core";
import { HttpService } from './http.service';

@Injectable({
    providedIn: 'root'
  })
  
  export class BaseHttpService {
      constructor(private http: HttpService){
      }
  }
