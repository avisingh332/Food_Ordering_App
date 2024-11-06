import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../environment/environment';
import { RestaurantCreateRequestType } from '../models/request.model';

@Injectable({
  providedIn: 'root'
})
export class RestaurantService {
  restaurantDetails:any;
  baseApiUrl = environment.API_URL;
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
  
}
