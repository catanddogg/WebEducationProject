import { Injectable, EventEmitter } from '@angular/core';
import { HubConnection, HubConnectionBuilder, HttpTransportType } from '@aspnet/signalr';
import { ChatMessageView } from '../model/chat-message.view';

@Injectable({
    providedIn: 'root'
  })

export class SignalrService{
    private connection: HubConnection;
    private thenable: Promise<void>

    messageReceived = new EventEmitter<ChatMessageView>();

    constructor(){
        this.connection = new HubConnectionBuilder().withUrl("https://localhost:44357/chat", {
        skipNegotiation: true,
        transport: HttpTransportType.WebSockets
        }).build();

        this.registerOnServerEvents();

        this.thenable = this.connection.start();
    }

    sendMessage(message : ChatMessageView){
        this.thenable.then(()=>{
            this.connection.invoke("Send", message);
        });
    }

    registerOnServerEvents(): void {  
        this.connection.on('MessageReceived', (data: ChatMessageView) => {  
          this.messageReceived.emit(data);  
        });  
    } 
}