import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, ReplaySubject } from 'rxjs';
import { environment } from '../environment/environment';
import { CartItemCreateRequestType } from '../models/request.model';
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root'
})
export class CartService {
  
  private userCart = new BehaviorSubject<any>(undefined);
  baseApiUrl = environment.API_URL;
  constructor(private http:HttpClient, private authService:AuthService) { 
    this.getCart();
  }
  userCart$():Observable<any>{
    return this.userCart.asObservable();
  }
  getCart(){
    if(this.authService.getUser()!=undefined){
      this.http.get(`${this.baseApiUrl}/api/Cart`).subscribe({
        next:(resp)=>{
          this.userCart.next(resp)
        },
        error:(err)=>{
          console.log(err);
        }
       })
    }
  }
  addCartItem(cartItem:CartItemCreateRequestType):Observable<any>{
    return this.http.post(`${this.baseApiUrl}/api/Cart`,cartItem);
  }
}
