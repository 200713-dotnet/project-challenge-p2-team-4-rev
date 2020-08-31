import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Mapper } from './mapper';
import { Observable } from 'rxjs';
import { Message } from './message';

@Injectable({
  providedIn: 'root'
})
export class MessageService {
  private messageUrl = 'http://localhost:5000/api/room/getroom';
  private sendUrl = 'http://localhost:5000/api/room/AddMessage';
  message: Message 
  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };
  getMessages(): Observable<Mapper> {
    return this.http.get<Mapper>(this.messageUrl);
  }
  sendMessage(UserName: string, Content: string):void
  {
    this.http.post(this.sendUrl,{userName : UserName,content: Content },this.httpOptions).subscribe();

  }
  constructor(private http: HttpClient) { }
}
