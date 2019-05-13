import { Injectable } from '@angular/core';
import { CookieService } from 'ngx-cookie-service';
import * as AuthConstants from '../constants/auth.constants';
import { of } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private cookieService: CookieService) { }

  public get isAuth() {
    var token = this.cookieService.get(AuthConstants.TokenName);
    return token.length && token !== '';
  }

  public logout() {
    this.cookieService.delete(AuthConstants.TokenName);
    return of(true);
  }

  public get getUserId() {
    return JSON.parse(window.atob(this.cookieService.get(AuthConstants.TokenName).split('.')[1])).UserId;
  }
}
