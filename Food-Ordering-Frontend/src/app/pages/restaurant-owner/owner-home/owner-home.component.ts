import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { RestaurantService } from 'src/app/services/restaurant.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-owner-home',
  templateUrl: './owner-home.component.html',
  styleUrls: ['./owner-home.component.css']
})
export class OwnerHomeComponent implements OnInit {

  restaurantDetails:any;
  isLoading:boolean=true;
  constructor(private restaurantService:RestaurantService, private router:Router ) {}
  ngOnInit(): void {
    this.getRestaurantDetails();
    // this.restaurantService.ownerRestaurantDetails$().subscribe({
    //   next:(val)=>{
    //     if(val!=null || val != undefined){
    //       this.restaurantDetails = val;
    //     }
    //   }
    // })
  }

  getRestaurantDetails(){
    this.restaurantService.getAllRestaurants().subscribe({
      next:(resp)=>{
        if(resp.length<=0){
          // if owner has not registered any Restaurant
          this.router.navigate(['restaurant-owner','add-update']);
          Swal.fire({
            position: "top-end",
            icon: "warning",
            title: "Add Your Restaurant!!!!",
            showConfirmButton: false,
            timer: 1500, 
            toast:true,
          });
        }
        else{
          this.restaurantDetails = resp[0];
          this.restaurantService.restaurantDetails = resp[0];
        }
        this.isLoading = false;
      },
      error:(err)=>{
        console.log("Error");
      }
    })
  }

}
