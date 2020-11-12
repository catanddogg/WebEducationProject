import { Component, OnInit } from '@angular/core';
import { ChatMessageView } from 'src/app/shared/model/chat-message.view';
import { SignalrService } from 'src/app/shared/services/signalr.service';

@Component({
  selector: 'app-chat',
  templateUrl: './chat.component.html',
  styleUrls: ['./chat.component.scss']
})
export class ChatComponent implements OnInit {

  private chatMessage : ChatMessageView;
  private chatMessages : ChatMessageView[];
  private userName : string;

  constructor(private signalrService: SignalrService) { 
    this.chatMessages = [];
    this.chatMessage = new ChatMessageView(); 
    this.userName = localStorage.getItem("UserName");
  }

  ngOnInit() {
    this.subscribeToEvents();
  }

  sendMessage(event: any){
    this.chatMessage.name = this.userName;
    this.signalrService.sendMessage(this.chatMessage)
    this.chatMessage = new ChatMessageView();
  }

  subscribeToEvents(){
    this.signalrService.messageReceived.subscribe((message : ChatMessageView)=> {
      this.chatMessages.push(message);
    });
  }

}
