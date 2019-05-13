import { Component, OnInit } from '@angular/core';
import { DialogsService } from '../dialogs.service';
import { MatIconRegistry } from '@angular/material';
import { DomSanitizer } from '@angular/platform-browser';
import { finalize } from 'rxjs/operators';
import { Message, Dialog } from '../dialog.model';

@Component({
  selector: 'app-dialogs-list',
  templateUrl: './dialogs-list.component.html',
  styleUrls: ['./dialogs-list.component.scss']
})
export class DialogsListComponent implements OnInit {

  dialogs: Dialog[];
  isLoading = false;

  constructor(private dialogService: DialogsService, iconRegistry: MatIconRegistry, sanitizer: DomSanitizer) {
    iconRegistry.addSvgIcon(
      'person',
      sanitizer.bypassSecurityTrustResourceUrl('assets/img/baseline-person-24px.svg'));
  }

  ngOnInit() {
    this.isLoading = true;

    this.dialogService.getDialogs()
      .pipe(finalize(() => this.isLoading = false))
      .subscribe(dialogs => {
        dialogs.forEach(item => {
          return item.messages.sort((a: Message, b: Message) => {
            return b.id - a.id;
          });
        });
        this.dialogs = dialogs;
      });
  }
}
