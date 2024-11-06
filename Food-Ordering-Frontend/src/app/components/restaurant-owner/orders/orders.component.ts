import { Component, OnInit } from '@angular/core';
import { RestaurantService } from 'src/app/services/restaurant.service';

@Component({
  selector: 'app-orders',
  templateUrl: './orders.component.html',
  styleUrls: ['./orders.component.css']
})
export class OrdersComponent implements OnInit {
  orders:any;
  constructor(private restaurantService:RestaurantService) {
  }
  ngOnInit(): void {
    this.orders = this.restaurantService.restaurantDetails.orders;
  }

}
