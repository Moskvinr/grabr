import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { OrdersService } from '../orders.service';
import { Observable } from 'rxjs';
import { map, finalize } from 'rxjs/operators';

@Component({
  selector: 'app-edit-order',
  templateUrl: './edit-order.component.html',
  styleUrls: ['./edit-order.component.scss']
})
export class EditOrderComponent implements OnInit {

  public order$: Observable<Order>;
  public order: Order;
  public orderId: number;
  public loading = false;
  constructor(private route: ActivatedRoute, private router: Router, private orderService: OrdersService) { }

  ngOnInit() {
    this.getOrder();
  }

  getOrder() {
    this.loading = true;
    const orderId = this.route.snapshot.params['id'];
    this.orderService.getOrder(orderId)
      .pipe(finalize(() => this.loading = false))
      .subscribe(order => {
        this.order = order;
      });
  }

  navigateBack() {
    this.router.navigateByUrl('/orders');
  }

  cancel() {
    this.navigateBack();
  }

  submit(order: Order) {
    this.loading = true;
    this.orderService.updateOrder(order.id, order)
      .pipe(finalize(() => this.loading = false))
      .subscribe(() => {
        this.navigateBack();
      });
  }
}
