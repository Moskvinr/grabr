import {
  Component, Input, Optional, ChangeDetectorRef, OnInit,
  OnDestroy
} from '@angular/core';
import { FormControl } from '@angular/forms';
import { ControlWrapComponent } from '../control-wrap/control-wrap.component';

@Component({
  selector: 'app-control',
  templateUrl: './control.component.html',
  styleUrls: ['./control.component.scss']
})
export class ControlComponent implements OnInit, OnDestroy {

  @Input() control: FormControl;
  @Input() noMargin = false;
  @Input() errorMessages: object;
  @Input() showErrorsOnTouch = true;
  @Input() showErrorsOnDirty = false;
  @Input() showErrorsByHandle = false;
  @Input() classNames: string;
  @Input() disableInvalidClassName = false;
  constructor(@Optional() private wrap: ControlWrapComponent, private changeDetector: ChangeDetectorRef) { }

  ngOnInit() {
    if (this.wrap) { this.wrap.addControl(this); }
  }

  ngOnDestroy() {
    if (this.wrap) { this.wrap.removeControl(this); }
  }
  public setShowErrorsByHandle(showErrors: boolean): void {
    this.showErrorsByHandle = showErrors;
    this.changeDetector.markForCheck();
  }

  public get showErrors(): boolean {
    return this.errorMessages && this.hasDanger;
  }

  public get hasDanger(): boolean {
    return this.control && this.control.invalid && this.canShowControlErrors;
  }

  public get hasSuccess(): boolean {
    return this.control && this.control.valid && this.canShowControlErrors;
  }

  public get elClassNames(): string {
    let result = 'form-group';
    if (this.hasDanger && !this.disableInvalidClassName) { result += ' has-danger'; }
    if (this.hasSuccess) { result += ' has-success'; }
    if (this.classNames) { result += ` ${this.classNames}`; }
    if (this.noMargin) { result += ' mb-0'; }
    return result;
  }

  private get canShowControlErrors(): boolean {
    if (this.showErrorsByHandle) { return true; }
    if (this.showErrorsOnTouch && this.showErrorsOnDirty) {
      return this.control.dirty && this.control.touched;
    }
    if (this.showErrorsOnTouch) { return this.control.touched; }
    if (this.showErrorsOnDirty) { return this.control.dirty; }
    return false;
  }
}
