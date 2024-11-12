import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { OrderStatus } from '../models/generic.model';
import { environment } from '../environment/environment';

@Injectable({
  providedIn: 'root'
})
export class OrderService {
  baseApiUrl = environment.API_URL;
  constructor(private http:HttpClient) { }

  updateOrderStatus(orderId:string, status:OrderStatus){
    return this.http.put(`${this.baseApiUrl}/api/Order/${orderId}/OrderStatus`,status);
  }
  placeOrder(cartId:string){
    return this.http.post(`${this.baseApiUrl}/api/Order/${cartId}`,{});
  }
}
