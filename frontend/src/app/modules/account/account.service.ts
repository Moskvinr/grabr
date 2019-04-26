import { Injectable } from '@angular/core';
import { CookieService } from 'ngx-cookie-service';
import { HttpClient } from '@angular/common/http';
import { Registration } from './models/registrations.model';
import { environment } from '../../../environments/environment';
import * as AccountRoutes from './constants/account.routing.constants';
import { Login } from './models/login.model';
import { tap } from 'rxjs/operators';
import { UserInfo } from 'src/app/common/models/user-info.model';
import { TokenName } from 'src/app/common/constants/auth.constants';
import { ChangePassword } from './models/change-password.model';

@Injectable({
  providedIn: 'root'
})
export class AccountService {

  constructor(private cookieService: CookieService, private client: HttpClient) { }

  public registration(registrationModel: Registration) {
    return this.client.post(environment.apiUrl + AccountRoutes.Registration, registrationModel);
  }

  public login(loginModel: Login) {
    return this.client.post<UserInfo>(environment.apiUrl + AccountRoutes.Login, loginModel)
      .pipe(tap(userModel => this.setCookie(userModel)));
  }

  public logout() {
    this.cookieService.delete(TokenName);
  }

  private setCookie(userModel: UserInfo) {
    const token = userModel.accessToken;
    this.cookieService.set(TokenName, token, 30, '/');
  }

  public changePassword(changePasswordModel: ChangePassword) {
    return this.client.post(environment.apiUrl + AccountRoutes.ChangePassword, changePasswordModel);
  }

}
