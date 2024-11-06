import { Component, inject, OnInit } from '@angular/core';
import { RestaurantService } from 'src/app/services/restaurant.service';

@Component({
  selector: 'app-customer-home',
  templateUrl: './customer-home.component.html',
  styleUrls: ['./customer-home.component.css']
})
export class CustomerHomeComponent implements OnInit {
  restaurantList:any;
  isLoading:boolean = true;
  restaurantService:RestaurantService = inject(RestaurantService);

  ngOnInit(): void {
    this.restaurantService.getAllRestaurants().subscribe({
      next:(resp)=>{
        this.restaurantList = resp;
        this.isLoading = false;
      }, 
      error:(err)=>{
        console.log(err);
      }
    })
  }

}
