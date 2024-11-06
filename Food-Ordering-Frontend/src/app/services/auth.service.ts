import { Injectable } from '@angular/core';
import { User } from '../models/generic.model';
import { BehaviorSubject, catchError, map, Observable, throwError } from 'rxjs';
import { environment } from '../environment/environment';
import { HttpClient } from '@angular/common/http';
import { LoginResponse } from '../models/response.model';

@Injectable({
  providedIn: 'root'
})

export class AuthService  {

  private user = new BehaviorSubject<User|undefined>(undefined);

  baseApiUrl = environment.API_URL;

  constructor(private http:HttpClient) {
    var user = this.getUser();
    if(user!=undefined){
      this.setUser(user);
    }
  }

  user$():Observable<User|undefined>{
    return this.user.asObservable();
  }

  setUser(user: User): void {

    this.user.next(user);
    localStorage.setItem('user-id', user.userId);
    localStorage.setItem('user-email', user.email);
    localStorage.setItem('user-roles', user.roles.join(','));
    localStorage.setItem('name', user.name);
    localStorage.setItem('token', user.token);
  }

  getUser(): User | undefined {
    const email = localStorage.getItem('user-email'); 
    const roles = localStorage.getItem('user-roles'); 
    const name = localStorage.getItem('name');
    const token = localStorage.getItem('token');
    const userid = localStorage.getItem('user-id');
    if(email && roles && name && token && userid){
      const user : User = {
        userId:userid,
        email: email,
        roles: roles.split(','),
        name: name,
        token : token,
      };

      return user;
    }
    return undefined;
  }
 
 

  login(loginDetail: any): Observable<LoginResponse>{
    return this.http.post<any>(`${this.baseApiUrl}/api/Auth/Login`, loginDetail).pipe(
      map((resp) => {
        if (resp.isSuccess) {
          return resp.result;  // Pass the result to the component
        } else {
          throw new Error(resp.message);  // Handle errors
        }
      }),
      catchError((error) => {
        console.error(error);  // Log error in case of failure
        return throwError(() => new Error('Error Fetching Movie'));  // Return an error observable
      })
    )
  }

  logout(): void {
    localStorage.clear();
    this.user.next(undefined);
  }
}