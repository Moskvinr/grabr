import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AccountService } from '../../account.service';
import { Router } from '@angular/router';
import { confirmPasswordValidator } from '../../validators/confirm-password-validator';
import { Registration } from '../../models/registrations.model';
declare var require: any;
const validationMessages = require('./validation.messages.json');

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.scss']
})
export class RegistrationComponent implements OnInit {

  public registerForm: FormGroup;
  public validationMessages = validationMessages;
  private fieldsRequirement = {
    email: true,
    userName: true,
    password: true,
    confirmPassword: true
  };

  constructor(private fb: FormBuilder, private accountService: AccountService, private router: Router) { }

  ngOnInit() {
    this.fillForm();
  }

  fillForm() {
    this.registerForm = this.fb.group({
      email: ['', [Validators.required, Validators.email]],
      userName: ['', [Validators.required]],
      firstName: [''],
      secondName: [''],
      password: ['', [Validators.required, Validators.minLength(8), Validators.maxLength(20)]],
      confirmPassword: ['', [Validators.required, Validators.minLength(8), Validators.maxLength(20)]]
    }, [confirmPasswordValidator]
    );
  }

  public isRequired(fieldName): boolean {
    return this.fieldsRequirement[fieldName];
  }

  submit() {
    if (this.registerForm.valid) {
      const loginModel: Registration = Object.assign({}, this.registerForm.value);
      this.accountService.registration(loginModel).subscribe(() => {
        this.registerForm.reset();
        this.router.navigate(['account', 'login']);
      });
    }
  }
}
