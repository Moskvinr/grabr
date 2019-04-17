import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ErrorComponent } from './components/error/error.component';
import { ErrorsListComponent } from './components/errors-list/errors-list.component';
import { LabelComponent } from './components/label/label.component';
import { ControlComponent } from './components/control/control.component';
import { ControlWrapComponent } from './components/control-wrap/control-wrap.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { FormsErrorMessagesPipe } from './pipes/error-messages.pipe';
import { MaterialErrorListComponent } from './components/material-error-list/material-error-list.component';
import { MaterialModule } from 'src/app/material.module';

@NgModule({
  declarations: [
    ErrorComponent,
    ErrorsListComponent,
    LabelComponent,
    ControlComponent,
    ControlWrapComponent,
    FormsErrorMessagesPipe,
    MaterialErrorListComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    MaterialModule
  ],
  exports: [
    ErrorComponent,
    ErrorsListComponent,
    LabelComponent,
    ControlComponent,
    ControlWrapComponent,
    MaterialErrorListComponent
  ]
})
export class FormsControlModule { }
