import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { OrdersService } from '../orders.service';
import { map, finalize } from 'rxjs/operators';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthService } from 'src/app/common/services/auth.service';

@Component({
  selector: 'app-order-details',
  templateUrl: './order-details.component.html',
  styleUrls: ['./order-details.component.scss']
})
export class OrderDetailsComponent implements OnInit {

  order: Order;
  orderId: number;
  isloading: boolean;

  constructor(private route: ActivatedRoute,
    private router: Router,
    private orderService: OrdersService,
    private authService: AuthService) { }

  ngOnInit() {
    this.isloading = true;
    this.orderId = this.route.snapshot.params['id'];
    this.orderService.getOrder(this.orderId).subscribe(order => {
      this.order = order;
      this.isloading = false;
    });
  }

  deliverOrder(id: number) {
    this.orderService.deliverOrder(id).subscribe(() => {
      this.router.navigateByUrl('../');
    });
  }

  get canDeliver() {
    return this.order.orderByUserId !== this.authService.getUserId && !this.order.deliveryManUserId;
  }

  get canCancelDeliver() {
    return this.order.deliveryManUserId === this.authService.getUserId;
  }

  get canDoActions() {
    return this.order.orderBy.id === this.authService.getUserId;
  }

  cancelDeliver() {
    this.orderService.cancelDeliver(this.order.id).subscribe(() => {
      this.router.navigateByUrl('../');
    });
  }

  edit() {
    this.router.navigateByUrl(`/orders/edit/${this.orderId}`);
  }

  delete() {
    this.isloading = true;
    this.orderService.deleteOrder(this.orderId)
      .pipe(finalize(() => this.isloading = false))
      .subscribe(() => {
        this.router.navigateByUrl('/orders');
      });
  }

}
