import { Component, OnInit, OnChanges, OnDestroy, Input } from '@angular/core';

@Component({
  selector: 'app-control-wrap',
  templateUrl: './control-wrap.component.html',
  styleUrls: ['./control-wrap.component.scss']
})
export class ControlWrapComponent implements OnChanges, OnDestroy {

  @Input() showErrors: boolean;

  private formControls = new Set();

  ngOnChanges(changes) {
    if (changes.hasOwnProperty('showErrors')) {
      this.formControls.forEach((formControl) => {
        formControl.setShowErrorsByHandle(this.showErrors);
      });
    }
  }

  ngOnDestroy() {
    this.formControls.clear();
  }

  public addControl(control) {
    this.formControls.add(control);
  }

  public removeControl(control) {
    this.formControls.delete(control);
  }

}
