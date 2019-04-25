import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { OrdersService } from '../orders.service';
import { map } from 'rxjs/operators';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-order-details',
  templateUrl: './order-details.component.html',
  styleUrls: ['./order-details.component.scss']
})
export class OrderDetailsComponent implements OnInit {

  order: Order;
  orderId: number;
  isloading: boolean;

  constructor(private route: ActivatedRoute, private orderService: OrdersService) { }

  ngOnInit() {
    this.isloading = true;
    const orderId = this.route.snapshot.params['id'];
    this.orderService.getOrder(orderId).subscribe(order => {
      this.order = order;
      this.isloading = false;
    });
  }

}
