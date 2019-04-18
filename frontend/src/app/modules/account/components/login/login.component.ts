import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, ValidationErrors } from '@angular/forms';

import { AccountService } from '../../account.service';
import { Router } from '@angular/router';
import { Login } from '../../models/login.model';
import { FormlyFieldConfig, FormlyFormOptions } from '@ngx-formly/core';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  loginForm = new FormGroup({});
  model: any = {};
  options: FormlyFormOptions = {};
  fields: FormlyFieldConfig[];

  constructor(private fb: FormBuilder, private accountService: AccountService, private router: Router) { }

  ngOnInit() {
    this.fillForm();
  }

  fillForm() {
    this.fields = [
      {
        key: 'email',
        type: 'input',
        templateOptions: {
          label: 'email',
          placeholder: 'Введите ваш email',
          required: true,
          type: 'email'
        },
        validators: {
          validation: [Validators.email]
        }
      },
      {
        key: 'password',
        type: 'input',
        templateOptions: {
          label: 'Пароль',
          placeholder: 'Введите ваш пароль',
          required: true,
          type: 'password'
        }
      }
    ];
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
