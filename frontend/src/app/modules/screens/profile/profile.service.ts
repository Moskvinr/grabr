import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { CookieService } from 'ngx-cookie-service';
import { TokenName } from 'src/app/common/constants/auth.constants';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProfileService {

  constructor(private http: HttpClient, private cookie: CookieService) { }

  public getUserInfo(): Observable<Profile> {
    return this.http.get<Profile>(environment.apiUrl + '/profile/getinfo');
  }

  public getOtherUserInfo(id: string): Observable<Profile> {
    return this.http.get<Profile>(environment.apiUrl + '/profile/getinfo/' + id);
  }

  roleMatch(allowedRoles: string[]) {
    const roleKey = 'http://schemas.microsoft.com/ws/2008/06/identity/claims/role';
    let isMatch = false;
    let payLoad = JSON.parse(window.atob(this.cookie.get(TokenName).split('.')[1]));
    let userRole = payLoad[roleKey];
    allowedRoles.forEach(element => {
      if (userRole === element) {
        isMatch = true;
        return false;
      }
    });
    return isMatch;
  }
}
