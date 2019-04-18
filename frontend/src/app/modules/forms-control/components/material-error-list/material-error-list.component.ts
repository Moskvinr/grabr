import { Component, OnInit, Input, OnDestroy } from '@angular/core';
import { AbstractControl, ValidationErrors } from '@angular/forms';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-material-error-list',
  templateUrl: './material-error-list.component.html',
  styleUrls: ['./material-error-list.component.scss']
})
export class MaterialErrorListComponent implements OnInit, OnDestroy {

  @Input() errors: object;
  @Input() control: AbstractControl;
  outputErrors: string[];
  value: Subscription;

  constructor() { }

  ngOnInit() {
    this.value = this.control.valueChanges.subscribe(value => {
      console.log(value);
      const validationErrors = this.control.errors as ValidationErrors;
      console.log(validationErrors);
      console.log(this.errors);
    });
    // this.control.valueChanges.subscribe(control => {
    //   console.log(this.control);
    //   console.log(this.control.errors);
    //   // const controlErrors: ValidationErrors = control.errors;
    //   // if (controlErrors != null) {
    //   // Object.keys(controlErrors).forEach(keyError => {
    //   //   console.log('Key control: ' + control.value + ', keyError: ' + keyError + ', err value: ', controlErrors[keyError]);
    //   // });
    //   // }
    // });
  }

  ngOnDestroy() {
    this.value.unsubscribe();
  }

}
