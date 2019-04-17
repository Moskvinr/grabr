import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, ValidationErrors } from '@angular/forms';

import { AccountService } from '../../account.service';
import { Router } from '@angular/router';
import { Login } from '../../models/login.model';
declare var require: any;
const validationMessages = require('./validation.messages.json');

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  public loginForm: FormGroup;
  public validationMessages = validationMessages;
  private fieldsRequirement = {
    email: true,
    password: true
  };

  constructor(private fb: FormBuilder, private accountService: AccountService, private router: Router) { }

  ngOnInit() {
    this.fillForm();
    this.loginForm.controls['email'].valueChanges.subscribe(value => {
      console.log(value);
      const validationErrors = this.loginForm.controls['email'].errors as ValidationErrors;
      console.log(validationErrors);
      console.log(this.validationMessages.filter(e => e.name === 'email')[0]);
    });
  }

  fillForm() {
    this.loginForm = this.fb.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required]]
    });
  }

  public isRequired(fieldName): boolean {
    return this.fieldsRequirement[fieldName];
  }

  submit() {
    if (this.loginForm.valid) {
      const loginModel: Login = Object.assign({}, this.loginForm.value);
      this.accountService.login(loginModel).subscribe(() => {
        this.loginForm.reset();
        this.router.navigate(['home']);
      });
    }
  }
}
