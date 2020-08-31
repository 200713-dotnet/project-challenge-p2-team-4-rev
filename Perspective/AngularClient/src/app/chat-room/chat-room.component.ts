import { Component, OnInit } from '@angular/core';
import { Message } from '../message';
import {MessageService} from '../message.service'
import { FormControl } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
@Component({
  selector: 'app-chat-room',
  templateUrl: './chat-room.component.html',
  styleUrls: ['./chat-room.component.css']
})
export class ChatRoomComponent implements OnInit {
  Messages: Message[];
  MessageSend : Message = {userName : "henry",content : "enter message here"};
  Alert: string = "";
  SendMessageControl = new FormControl('');
  getmessages(): void {
    this.messageService.getMessages()
    .subscribe(Messages => this.Messages = Messages.messages);
  }
  send(): void {
    this.messageService.sendMessage(this.MessageSend.userName, this.MessageSend.content);
    this.Alert = "Message sent";
    this.getmessages();
  }
  constructor(private messageService: MessageService, private http: HttpClient) { }

  ngOnInit(): void {
    this.getmessages();
  }

}
