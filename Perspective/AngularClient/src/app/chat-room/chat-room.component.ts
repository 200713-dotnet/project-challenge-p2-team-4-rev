import { Component, OnInit } from '@angular/core';
import { Message } from '../message';

@Component({
  selector: 'app-chat-room',
  templateUrl: './chat-room.component.html',
  styleUrls: ['./chat-room.component.css']
})
export class ChatRoomComponent implements OnInit {
  Messages: Message[];
  MessageSend : Message;

  getmessages(): void {
    this.messageService.getMessages()
    .subscribe(Messages => this.Messages = Messages);
  }
  constructor(private messageService) { }

  ngOnInit(): void {
  }

}
