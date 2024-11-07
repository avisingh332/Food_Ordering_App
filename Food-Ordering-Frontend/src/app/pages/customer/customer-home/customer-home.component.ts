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
  searchString :string = "";
  restaurantService:RestaurantService = inject(RestaurantService);

  ngOnInit(): void {
    this.loadInitialData();
  }
  loadInitialData(){
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
  handleSearch(){
    // this.isLoading= true;
    if(this.searchString.trim().length >0){
      this.restaurantService.searchRestaurant(this.searchString).subscribe({
        next:(restaurants) =>{
          this.restaurantList = restaurants;
          // this.isLoading = false;
        }
        ,error:(err)=>{
          console.log(err);
        }
      })
    }
    else{
      this.loadInitialData();
    }
  }

}
