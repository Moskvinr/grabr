import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-label',
  templateUrl: './label.component.html',
  styleUrls: ['./label.component.scss']
})
export class LabelComponent {

  @Input() attrFor: string = null;
  @Input() asRequired = false;
  @Input() style: object;
  @Input() styleClass: string;

  public get classNames() {
    let result = '';
    if (this.asRequired) { result += 'label-required '; }
    if (this.styleClass) { result += this.styleClass; }
    return result;
  }
}
