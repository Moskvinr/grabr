import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './components/login/login.component';
import { RegistrationComponent } from './components/registration/registration.component';
import { AccountRoutingModule } from './account-routing.module';
import { FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { FormsControlModule } from '../forms-control/forms-control.module';
import { MaterialModule } from 'src/app/material.module';
import { FormlyMaterialModule } from '@ngx-formly/material';
import { FormlyModule } from '@ngx-formly/core';
import { ValidationMessageOption } from '@ngx-formly/core/lib/services/formly.config';
declare var require: any;
const validationMessages = require('./validation-messages.json');


function getMessages() {
  let errMessages: ValidationMessageOption[] = [];
  for (let element of validationMessages) {
    errMessages.push({ name: element.name, message: element.message });
  }
  return errMessages;
}

@NgModule({
  imports: [
    CommonModule,
    AccountRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    FormsControlModule,
    MaterialModule,
    FormlyModule.forChild({
      validationMessages: getMessages()
    }),
    FormlyMaterialModule
  ],
  declarations: [LoginComponent, RegistrationComponent]
})
export class AccountModule { }
