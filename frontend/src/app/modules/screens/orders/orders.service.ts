import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, BehaviorSubject } from 'rxjs';
import { environment } from 'src/environments/environment';
import { first, map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class OrdersService {

  // orders: Observable<Order[]>;
  // private _orders: BehaviorSubject<Order[]>;
  // private dataStore: {
  //   orders: Order[]
  // };

  // constructor(private http: HttpClient) {
  //   this.dataStore = { orders: [] };
  //   this._orders = <BehaviorSubject<Order[]>>new BehaviorSubject([]);
  //   this.orders = this._orders.asObservable();
  // }

  // getAll() {
  //   this.http.get<Order[]>(`${environment.apiUrl}/order/getall`).subscribe(data => {
  //     this.dataStore.orders = data;
  //     this._orders.next(Object.assign({}, this.dataStore).orders);
  //   });
  // }

  // getOrder(id: number) {
  //   this.http.get<Order>(`${environment.apiUrl}/order/get/${id}`).subscribe(data => {
  //     let itemNotExist = true;

  //     this.dataStore.orders.forEach((item, index) => {
  //       if (item.id === data.id) {
  //         this.dataStore.orders[index] = data;
  //         itemNotExist = false;
  //       }
  //     });

  //     if (itemNotExist) {
  //       this.dataStore.orders.push(data);
  //     }

  //     this._orders.next(Object.assign({}, this.dataStore).orders);
  //   });
  // }

  // createOrder(order: Order) {
  //   this.http.post<number>(`${environment.apiUrl}/order/create`, order).subscribe(id => {
  //     this.getOrder(id);
  //   });
  // }

  // updateOrder(id: number, order: Order) {
  //   this.http.put(`${environment.apiUrl}/order/update/${id}`, order).subscribe(() => {
  //     this.getOrder(id);
  //   });
  // }

  // deleteOrder(id: number) {
  //   this.http.delete(`${environment.apiUrl}/order/delete/${id}`).subscribe(() => {
  //     this.dataStore.orders.forEach((order, index) => {
  //       if (order.id === id) {
  //         this.dataStore.orders.splice(index, 1);
  //       }
  //     });
  //     this._orders.next(Object.assign({}, this.dataStore).orders);
  //   });
  // }

  constructor(private http: HttpClient) { }

  getAll() {
    return this.http.get<Order[]>(`${environment.apiUrl}/order/getall`);
  }

  getOrder(id: number) {
    return this.http.get<Order>(`${environment.apiUrl}/order/get/${id}`);
  }
  createOrder(order: Order) {
    return this.http.post<number>(`${environment.apiUrl}/order/create`, order);
  }

  updateOrder(id: number, order: Order) {
    console.log('kek');
    return this.http.put(`${environment.apiUrl}/order/update/${id}`, order);
  }

  deleteOrder(id: number) {
    return this.http.delete(`${environment.apiUrl}/order/delete/${id}`);
  }
}
