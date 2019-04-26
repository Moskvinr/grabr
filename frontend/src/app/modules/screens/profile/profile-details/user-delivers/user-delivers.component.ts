import { Component, OnInit, Input } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-user-delivers',
  templateUrl: './user-delivers.component.html',
  styleUrls: ['./user-delivers.component.scss']
})
export class UserDeliversComponent implements OnInit {

  @Input() userDelivered: Order[];
  constructor(public router: Router) { }

  ngOnInit() {
  }
}
