import { Component, OnInit } from '@angular/core';
import { RestaurantService } from 'src/app/services/restaurant.service';

@Component({
  selector: 'app-owner-home',
  templateUrl: './owner-home.component.html',
  styleUrls: ['./owner-home.component.css']
})
export class OwnerHomeComponent implements OnInit {
  restaurantDetail:any;
  isLoading:boolean=true;
  constructor(private restaurantService:RestaurantService ) {}
  ngOnInit(): void {
    this.getRestaurantDetails();
  }

  getRestaurantDetails(){
    this.restaurantService.getAllRestaurants().subscribe({
      next:(resp)=>{
        
        if(resp.length<=0){
        }
        else{
          this.restaurantDetail = resp[0];
          this.restaurantService.restaurantDetails = resp[0];
          // console.log("Restaurant Details ", this.restaurantDetail);

        }
        this.isLoading = false;
      },
      error:(err)=>{
        console.log("Error");
      }
    })
  }

}
