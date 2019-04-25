import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NewOrderComponent } from './new-order/new-order.component';
import { OrdersListComponent } from './orders-list/orders-list.component';
import { EditOrderComponent } from './edit-order/edit-order.component';
import { OrderDetailsComponent } from './order-details/order-details.component';
import { OrdersRoutingModule } from './orders-routing.module';
import { MaterialModule } from 'src/app/material.module';
import { OrdersService } from './orders.service';
import { OrderFormComponent } from './order-form/order-form.component';
import { ValidationMessageOption } from '@ngx-formly/core/lib/services/formly.config';
import { FormlyModule } from '@ngx-formly/core';
import { FormlyMaterialModule } from '@ngx-formly/material';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
declare var require: any;
const validationMessages = require('./order-form/validation-messages.json');


function getMessages() {
  let errMessages: ValidationMessageOption[] = [];
  for (let element of validationMessages) {
    errMessages.push({ name: element.name, message: element.message });
  }
  return errMessages;
}
@NgModule({
  declarations: [OrderFormComponent, NewOrderComponent, OrdersListComponent, EditOrderComponent, OrderDetailsComponent],
  imports: [
    CommonModule,
    OrdersRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    MaterialModule,
    FormlyModule.forChild({
      validationMessages: getMessages()
    }),
    FormlyMaterialModule
  ],
  providers: [OrdersService]
})
export class OrdersModule { }
