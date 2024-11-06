import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { AuthService } from "../services/auth.service";
import { Observable } from "rxjs";
import { User } from "../models/generic.model";
import { Injectable } from "@angular/core";

@Injectable()
export class AuthInterceptor implements HttpInterceptor {
    
    constructor(private authService: AuthService) { }
    

    intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
       const user:User|undefined = this.authService.getUser();
        if (user && user.token ) {
            const clonedRequest = request.clone({
                setHeaders: {
                    Authorization: `Bearer ${user.token}`
                }
            });

            // console.log('Modified Request with Token:', clonedRequest);

            return next.handle(clonedRequest);
        }

        return next.handle(request);
    }
}