import { Injectable } from '@angular/core';
import { ReviewCreateRequestType } from '../models/request.model';
import { HttpClient } from '@angular/common/http';
import { environment } from '../environment/environment';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ReviewService {

  constructor(private http:HttpClient) { }
  baseApiUrl: string = environment.API_URL;
  addReview(review:ReviewCreateRequestType):Observable<any>{
    return this.http.post(`${this.baseApiUrl}/api/Review`, review);
  }
}
