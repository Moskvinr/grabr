import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Dialog, SendMessage } from './dialog.model';

@Injectable({
  providedIn: 'root'
})
export class DialogsService {

  constructor(private http: HttpClient) { }

  getDialogs() {
    return this.http.get<Dialog[]>(`${environment.apiUrl}/dialogs/getdialogs`);
  }

  sendMessage(message: SendMessage) {
    return this.http.post(`${environment.apiUrl}/dialogs/sendmessage`, message);
  }

  getDialogId(id: string) {
    return this.http.get<number>(`${environment.apiUrl}/dialogs/getdialogid/${id}`);
  }
}
