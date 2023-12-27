import { Injectable } from '@angular/core';
import * as signalR from '@microsoft/signalr';
import { Subject } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class HubService {
  private hubConnection: signalR.HubConnection;
  public notificationReceived = new Subject<string>();

  constructor() {
    this.hubConnection = new signalR.HubConnectionBuilder()
      .withUrl(environment.hubUrl)
      .build();

    this.hubConnection.start().catch((_) => console.error("Socket error"));

    this.hubConnection.on('ReceiveNotification', (data: string) => {
      this.notificationReceived.next(data);
    });
  }
}