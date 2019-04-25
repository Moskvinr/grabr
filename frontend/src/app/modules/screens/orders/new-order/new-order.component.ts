import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { OrdersService } from '../orders.service';

@Component({
  selector: 'app-new-order',
  templateUrl: './new-order.component.html',
  styleUrls: ['./new-order.component.scss']
})
export class NewOrderComponent implements OnInit {

  public order: Order;
  constructor(private route: ActivatedRoute, private router: Router, private orderService: OrdersService) { }

  ngOnInit() {
    this.order = this.createEmptyOrder();
  }

  createEmptyOrder(): Order {
    return {
      name: '',
      description: '',
      productPrice: 0,
      productLink: '',
      reward: 0,
      count: 0,
    };
  }

  navigateBack() {
    this.router.navigate(['../'], { relativeTo: this.route });
  }

  cancel() {
    this.navigateBack();
  }

  submit(order: Order) {
    this.orderService.createOrder(order);
    this.navigateBack();
  }

}
