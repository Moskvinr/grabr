import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NewOrderComponent } from './new-order/new-order.component';
import { OrdersListComponent } from './orders-list/orders-list.component';
import { EditOrderComponent } from './edit-order/edit-order.component';
import { OrderDetailsComponent } from './order-details/order-details.component';
import { OrdersRoutingModule } from './orders-routing.module';
import { MaterialModule } from 'src/app/material.module';

@NgModule({
  declarations: [NewOrderComponent, OrdersListComponent, EditOrderComponent, OrderDetailsComponent],
  imports: [
    CommonModule,
    OrdersRoutingModule,
    MaterialModule
  ]
})
export class OrdersModule { }
