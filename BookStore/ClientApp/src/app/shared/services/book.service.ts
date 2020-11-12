import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AllBookViewModel } from '../model/get-all-book.view';
import { Observable, BehaviorSubject } from 'rxjs';
import { environment } from 'src/environments/environment';
import { HttpService } from './http.service';

@Injectable({
    providedIn: 'root'
  })

export class BookService{

    baseUrl: string;
    private _books: BehaviorSubject<AllBookViewModel>;

    constructor(private http: HttpService){
        this._books = new BehaviorSubject<AllBookViewModel>(new AllBookViewModel);
    }

    public GetSearchForBookLibary(search : string): Observable<AllBookViewModel> {
        this.http.GetSearchForBookLibary(search)
        .subscribe(data =>{
            this._books.next(data);
        });

        return null;
    }
}