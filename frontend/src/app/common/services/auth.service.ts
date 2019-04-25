import { Injectable } from '@angular/core';
import { CookieService } from 'ngx-cookie-service';
import * as AuthConstants from '../constants/auth.constants';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private cookieService: CookieService) { }

  public get isAuth() {
    return this.cookieService.get(AuthConstants.TokenName).length ? true : false;
  }
}
