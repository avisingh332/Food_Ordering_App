import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { RestaurantService } from 'src/app/services/restaurant.service';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css']
})
export class MenuComponent implements OnInit {
  menuData:any;
  constructor(private restaurantService:RestaurantService) {
  }
   
  ngOnInit(): void {
    this.menuData=this.restaurantService.restaurantDetails.menus;
  }

}
