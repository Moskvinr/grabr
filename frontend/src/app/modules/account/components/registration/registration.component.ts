import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AccountService } from '../../account.service';
import { Router } from '@angular/router';
import { confirmPasswordValidator } from '../../validators/confirm-password-validator';
import { Registration } from '../../models/registrations.model';
import { FormlyFieldConfig, FormlyFormOptions } from '@ngx-formly/core';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.scss']
})
export class RegistrationComponent implements OnInit {

  registerForm: FormGroup = new FormGroup({});
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
          label: 'Ваша почта',
          placeholder: 'Введите ваш email',
          required: true,
          type: 'email'
        },
        validators: {
          validation: [Validators.email]
        }
      },
      {
        key: 'userName',
        type: 'input',
        templateOptions: {
          label: 'Логин',
          placeholder: 'Ваш логин',
          required: true,
          maxLength: 20
        }
      },
      {
        key: 'firstName',
        type: 'input',
        templateOptions: {
          label: 'Имя',
          placeholder: 'Ваше имя',
          required: false,
          maxLength: 20
        }
      },
      {
        key: 'secondName',
        type: 'input',
        templateOptions: {
          label: 'Фамилия',
          placeholder: 'Ваша фамилия',
          required: false,
          maxLength: 20
        }
      },
      {
        key: 'password',
        type: 'input',
        templateOptions: {
          label: 'Пароль',
          placeholder: 'Введите ваш пароль',
          required: true,
          type: 'password',
          minLength: 8,
          maxLength: 20
        }
      },
      {
        key: 'confirmPassword',
        type: 'input',
        templateOptions: {
          label: 'Повторите пароль',
          placeholder: 'Повторите введенный ранее пароль',
          required: true,
          type: 'password',
          minLength: 8,
          maxLength: 20
        },
        asyncValidators: { validation: [confirmPasswordValidator] }
      }
    ];
  }

  submit() {
    console.log(this.registerForm);
    if (this.registerForm.valid) {
      const loginModel: Registration = Object.assign({}, this.registerForm.value);
      this.accountService.registration(loginModel).subscribe(() => {
        this.registerForm.reset();
        this.router.navigate(['account', 'login']);
      });
    }
  }
}
