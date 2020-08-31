import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Message } from './message';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class MessageServiceService {
  private messageUrl = 'http://localhost:5000/room/getroom';
  getMessages(): Observable<Message[]> {
    return this.http.get<Message[]>(this.messageUrl)
  }
  constructor(private http: HttpClient) { }
}
