import { Injectable } from '@angular/core';
import { CookieService } from 'ngx-cookie-service';
import * as AuthConstants from '../constants/auth.constants';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private cookieService: CookieService) { }

  public get isAuth() {
    const token = this.cookieService.get(AuthConstants.TokenName);
    return token.length ? true : false;
  }
}
