import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NotificationsByUserIdView, NotificationsByUserIdViewItem } from '../../model/notifications-by-user-id.view';
import { HttpService } from '../../services/http.service';
import { CreateNotificationRequestView } from '../../model/create-notification-request.view';
import { NotificationService } from '../../services/toastr.service';

@Component({
  selector: 'app-footer',
  templateUrl: './footer.component.html',
  styleUrls: ['./footer.component.scss']
})
export class FooterComponent implements OnInit {

  public notificationVisibility: string;
  public notifications: NotificationsByUserIdView;

  constructor(private router: Router,
    private http: HttpService,
    private notificationService: NotificationService) { }

  ngOnInit() {
    this.notificationVisibility = 'hidden';
    this.notifications = new NotificationsByUserIdView;
    this.getNotificationsByUserId();
  }

  navigationToChat(){
    this.router.navigate(['/Storage/Chat']);
  }

  openNotificationBar(){
    if(this.notificationVisibility === 'visible'){
      this.notificationVisibility = 'hidden';
      return;
    }
    this.notificationVisibility = 'visible';
  }

  getNotificationsByUserId(){
    let userId = localStorage.getItem("UserId");

    this.http.GetNotificationsByUserId(userId)
    .subscribe(response =>{
      this.notifications = response;
    });
  }

  changeNotificationStatus(notification: NotificationsByUserIdViewItem){


  }

  createNotification(){
    var model = new CreateNotificationRequestView();
    model.imagePath = "http://getwallpapers.com/wallpaper/full/5/7/6/82493.jpg";
    model.title = "Test header";
    model.message = "Test message";

    this.http.CreateNotification(model)
    .subscribe(response => {
      this.notificationService.NotificationSuccess(response.message);
    });
  }
}