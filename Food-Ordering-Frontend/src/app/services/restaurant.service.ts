import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { environment } from '../environment/environment';
import { RestaurantCreateRequestType } from '../models/request.model';

@Injectable({
  providedIn: 'root'
})
export class RestaurantService {
  // private ownerRestaurantDetails= new BehaviorSubject<any>(undefined);
  restaurantDetails:any;
  baseApiUrl = environment.API_URL;

  // setOwnerRestaurantDetails(restaurantDetails:any){
  //   this.ownerRestaurantDetails.next(restaurantDetails);
  // }

  // ownerRestaurantDetails$():Observable<any>{
    
  //     return this.ownerRestaurantDetails.asObservable();
    
  // }
  constructor(private http:HttpClient) { }

  getAllRestaurants():Observable<any>{
    return this.http.get(`${this.baseApiUrl}/api/Restaurant`);
  }

  addRestaurant(request:RestaurantCreateRequestType):Observable<any>{
    return this.http.post(`${this.baseApiUrl}/api/Restaurant`, request);
  }
  getRestaurantById(id:string){
    return this.http.get(`${this.baseApiUrl}/api/Restaurant/${id}`);
  }

  searchRestaurant(searchString:string){
    return this.http.get(`${this.baseApiUrl}/api/Restaurant/Search?searchString=${searchString}`);
  }

  updateRestaurant(id:string, request:RestaurantCreateRequestType):Observable<any>{
    return this.http.put(`${this.baseApiUrl}/api/Restaurant/${id}`, request);
  }
}
