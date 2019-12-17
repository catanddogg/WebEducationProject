export class NotificationsByUserIdView{
   notifications: NotificationsByUserIdViewItem[];
   constructor(){
       this.notifications = [];
   }
}

export class NotificationsByUserIdViewItem{
    id: number;
    imagePath: string;
    message: string;
    title: string;
}