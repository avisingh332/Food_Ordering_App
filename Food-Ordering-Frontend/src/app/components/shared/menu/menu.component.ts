import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CartItemCreateRequestType } from 'src/app/models/request.model';
import { AuthService } from 'src/app/services/auth.service';
import { CartService } from 'src/app/services/cart.service';
import { RestaurantService } from 'src/app/services/restaurant.service';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css']
})
export class MenuComponent implements OnInit {
  menuData:any;
  userCart:any;
  isCustomer:boolean = false;
  constructor(private restaurantService:RestaurantService, private cartService:CartService, private authService:AuthService) {
  }
   
  ngOnInit(): void {
    this.menuData=this.restaurantService.restaurantDetails.menus;
    this.isCustomer = this.authService.getUser()?.roles.includes('Customer')|| false;
    if(this.isCustomer){
      this.cartService.userCart$().subscribe({
        next:(cart)=>{
          this.userCart = cart;
          this.processData();
        },
        error:(err)=>{
          console.log(err);
        }
      });
    }
  }

  processData() {
    this.menuData = (this.menuData as Array<any>).map(m => {
      let cartIndex = (this.userCart.cartItems as Array<any>).findIndex(ci=> ci.dishId == m.id);
      let quantity = cartIndex!=-1 ? this.userCart.cartItems[cartIndex].quantity : 0;
      return {
        ...m,
        quantity: quantity
      }
    })
  }

  updateCart(menu: any, isDecrement:boolean = false) {
    let reqObj: CartItemCreateRequestType = {
      cartId: this.userCart.id,
      dishId: menu.id,
      quantity:  isDecrement?-1:1,
    }
    // return;
    this.cartService.addCartItem(reqObj).subscribe({
      next: (cart) => {
        this.cartService.getCart();
      }
    })
  }

}
