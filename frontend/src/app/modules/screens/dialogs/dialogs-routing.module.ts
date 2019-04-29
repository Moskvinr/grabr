import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { DialogsListComponent } from './dialogs-list/dialogs-list.component';
import { DialogComponent } from './dialog/dialog.component';
import { AuthGuard } from 'src/app/guards/auth.guard';

const routes: Routes = [
  {
    path: '',
    component: DialogsListComponent
  },
  {
    path: ':id',
    component: DialogComponent
  }
];

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(routes)
  ],
  exports: [RouterModule]
})
export class DialogsRoutingModule { }
