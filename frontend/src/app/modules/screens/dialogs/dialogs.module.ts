import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DialogsListComponent } from './dialogs-list/dialogs-list.component';
import { DialogComponent } from './dialog/dialog.component';
import { RouterModule } from '@angular/router';
import { DialogsService } from './dialogs.service';
import { DialogsRoutingModule } from './dialogs-routing.module';
import { MaterialModule } from 'src/app/material.module';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [DialogsListComponent, DialogComponent],
  imports: [
    CommonModule,
    DialogsRoutingModule,
    MaterialModule,
    FormsModule
  ],
  providers: [DialogsService]
})
export class DialogsModule { }
