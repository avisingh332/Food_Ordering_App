import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { combineLatest, forkJoin, tap } from 'rxjs';
import { CartItemCreateRequestType } from 'src/app/models/request.model';
import { CartService } from 'src/app/services/cart.service';
import { RestaurantService } from 'src/app/services/restaurant.service';

@Component({
  selector: 'app-restaurant-details',
  templateUrl: './restaurant-details.component.html',
  styleUrls: ['./restaurant-details.component.css']
})
export class RestaurantDetailsComponent implements OnInit {
  restaurantId: string | undefined;
  restaurantDetails: any;
  userCart: any;
  isLoading: boolean = true;
  constructor(private route: ActivatedRoute, private cartService: CartService, private restaurantService: RestaurantService) {
  }

  ngOnInit(): void {
    this.route.paramMap.subscribe({
      next: (params) => {
        let id = params.get('id');
        if (id != null) {
          this.restaurantId = id;
          this.loadData(this.restaurantId);
        }
      },
    });
  }

  loadData(id: string) {
    this.restaurantService.getRestaurantById(id).subscribe({
      next:(restaurant)=>{
        this.restaurantDetails = restaurant;
        this.restaurantService.restaurantDetails = restaurant;
        this.isLoading = false;
      },
      error:(err)=>{
        console.log(err);
      }
    })
  }  
}
