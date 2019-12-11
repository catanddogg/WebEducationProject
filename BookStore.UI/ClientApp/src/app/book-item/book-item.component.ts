import { Component, OnInit, NgZone } from '@angular/core';
import { HttpService } from '../shared/services/http.service';
import { ActivatedRoute } from '@angular/router';
import { BookViewModel } from '../shared/model/book.view';
import { NotificationService } from '../shared/services/toastr.service';

@Component({
  selector: 'app-book-item',
  templateUrl: './book-item.component.html',
  styleUrls: ['./book-item.component.scss']
})

export class BookItemComponent implements OnInit {
  private sub: any;
  private book: BookViewModel;
  buttonTitle: string;

  constructor(private http: HttpService,
    private route: ActivatedRoute,
    private toastr: NotificationService) {
      this.book = new BookViewModel();
  }

  ngOnInit() {
    this.sub = this.route.params.subscribe(params => {
      let id = +params['id'];
      this.buttonTitle = "Create";
      if (id !== 0) {
        this.buttonTitle = "Update";
        this.getItemById(id);
      }
    });
  }

  private getItemById(id: number) {
    this.http.GetBookById(id)
      .subscribe(data => {
        this.book = data;
      });
  }

  private createOrUpdateBook() {
    if(this.buttonTitle === "Create"){
      this.http.CreateBook(this.book)
      .subscribe(data =>{
        if(data.success){
          this.toastr.NotificationSuccess(data.message);
        }
        if(!data.success){
          this.toastr.NotificationError(data.message);
        }
      });
    }
    if(this.buttonTitle === "Update"){
      this.http.UpdateBook(this.book)
      .subscribe(data =>{
        if(data.success){
          this.toastr.NotificationSuccess(data.message);
        }
        if(!data.success){
          this.toastr.NotificationError(data.message);
        }
      });
    }
  }
}
