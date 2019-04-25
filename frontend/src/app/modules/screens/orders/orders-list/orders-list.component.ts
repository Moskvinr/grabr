import { Component, OnInit } from '@angular/core';
import { OrdersService } from '../orders.service';
import { Observable } from 'rxjs';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';
import { switchMap } from 'rxjs/operators';

@Component({
  selector: 'app-orders-list',
  templateUrl: './orders-list.component.html',
  styleUrls: ['./orders-list.component.scss']
})
export class OrdersListComponent implements OnInit {
  orders: Observable<Order[]>;

  constructor(private orderService: OrdersService, public router: Router, private route: ActivatedRoute) { }

  ngOnInit() {
    this.orders = this.orderService.getAll();
  }

  createNew() {
  }

  details(id: number) {
    this.router.navigateByUrl(`orders/${id}`);
  }
}
