import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { OrdersListComponent } from './orders-list/orders-list.component';
import { OrderDetailsComponent } from './order-details/order-details.component';
import { EditOrderComponent } from './edit-order/edit-order.component';
import { NewOrderComponent } from './new-order/new-order.component';

const routes: Routes = [
  {
    path: '',
    component: OrdersListComponent
  },
  {
    path: ':id',
    component: OrderDetailsComponent
  },
  {
    path: 'edit/:id',
    component: EditOrderComponent
  },
  {
    path: 'new',
    component: NewOrderComponent
  }
];

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forChild(routes)
  ],
  exports: [RouterModule]
})
export class OrdersRoutingModule { }
