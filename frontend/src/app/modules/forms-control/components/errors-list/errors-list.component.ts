import { Component, OnInit, Input } from '@angular/core';
import { AbstractControl } from '@angular/forms';

@Component({
  selector: 'app-errors-list',
  templateUrl: './errors-list.component.html',
  styleUrls: ['./errors-list.component.scss']
})
export class ErrorsListComponent {

  @Input() control: AbstractControl;
  @Input() messages: object;
  @Input() styles: any;
  @Input() classNames: string;
}
