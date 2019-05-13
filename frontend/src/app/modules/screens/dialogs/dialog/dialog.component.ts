import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { DialogsService } from '../dialogs.service';
import { Dialog, SendMessage, Message } from '../dialog.model';
import { finalize } from 'rxjs/operators';

@Component({
  selector: 'app-dialog',
  templateUrl: './dialog.component.html',
  styleUrls: ['./dialog.component.scss']
})
export class DialogComponent implements OnInit {

  loading = false;
  message: string;
  dialogId: number;
  public dialog: Dialog;
  constructor(private route: ActivatedRoute, private router: Router, private dialogService: DialogsService) { }

  ngOnInit() {
    this.loading = true;
    let id = this.route.snapshot.params['id'];
    if (!Number.isInteger(Number(id))) {
      this.dialogService.getDialogId(id).subscribe(dialogId => {
        this.dialogId = dialogId;
        this.router.navigateByUrl(`/dialogs/${dialogId}`);
      });
    } else {
      this.dialogId = id;
    }
    this.getDialog();
  }

  getDialog() {
    this.dialogService.getDialogs()
      .pipe(finalize(() => {
        this.loading = false;
      }))
      .subscribe(dialogs => {
        this.dialog = dialogs.find(item => item.id == this.dialogId);
      });
  }

  public sendMessage() {
    let sendMessage: SendMessage = new SendMessage();

    sendMessage.dialogId = this.dialogId;
    sendMessage.messageBody = this.message;
    this.dialogService.sendMessage(sendMessage)
      .pipe(finalize(() => {
        this.getDialog();
        this.message = '';
      }))
      .subscribe(result => {
        var message = new Message();
        message.messageBody = sendMessage.messageBody;
        this.dialog.messages.push(message);
      });
  }

}
