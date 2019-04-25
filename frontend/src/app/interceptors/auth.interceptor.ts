import { Injectable } from '@angular/core';
import {
    HttpRequest,
    HttpHandler,
    HttpEvent,
    HttpInterceptor,
    HttpErrorResponse,
    HttpResponse
} from '@angular/common/http';
import { CookieService } from 'ngx-cookie-service';
import { Observable, of } from 'rxjs';
import { TokenName } from '../common/constants/auth.constants';
import { catchError, map } from 'rxjs/operators';
import { Router } from '@angular/router';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {

    constructor(public cookie: CookieService, private router: Router) { }

    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        const url = request.url;
        const isAccountRequest = url.indexOf('login') !== -1
            || url.indexOf('registration') !== -1;

        if (!isAccountRequest) {
            request = request.clone({
                setHeaders: {
                    Authorization: `Bearer ${this.cookie.get(TokenName)}`
                }
            });
        }
        return next.handle(request).pipe(
            catchError(err => {
                if (err.status === 401) {
                    this.cookie.delete(TokenName);
                    // tslint:disable-next-line:quotemark
                    this.router.navigateByUrl("/account/login");
                }
                return of(null);
            })
        );
    }
}
