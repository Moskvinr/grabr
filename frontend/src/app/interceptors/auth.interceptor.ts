import { Injectable } from '@angular/core';
import {
    HttpRequest,
    HttpHandler,
    HttpEvent,
    HttpInterceptor
} from '@angular/common/http';
import { CookieService } from 'ngx-cookie-service';
import { Observable } from 'rxjs';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {

    constructor(public cookie: CookieService) { }

    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        const url = request.url;
        const isAccountRequest = url.indexOf('login') !== -1
            || url.indexOf('registration') !== -1;

        if (!isAccountRequest) {
            request = request.clone({
                setHeaders: {
                    Authorization: `Bearer ${this.cookie.get('AuthToken')}`
                }
            });
        }
        return next.handle(request);
    }
}
