import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CartItemCreateRequestType } from 'src/app/models/request.model';
import { AuthService } from 'src/app/services/auth.service';
import { CartService } from 'src/app/services/cart.service';
import { RestaurantService } from 'src/app/services/restaurant.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css']
})
export class MenuComponent implements OnInit {
  menuData: any;
  userCart: any;
  isCustomer: boolean = false;
  constructor(private restaurantService: RestaurantService, private cartService: CartService, private authService: AuthService) {
  }

  ngOnInit(): void {
    this.menuData = this.restaurantService.restaurantDetails.menus;
    this.isCustomer = this.authService.getUser()?.roles.includes('Customer') || false;
    // console.log("isCustomer", this.isCustomer);
    if (this.isCustomer) {
      this.cartService.userCart$().subscribe({
        next: (cart) => {
          // console.log("got user cart ",cart)
          this.userCart = cart;
          this.processData();
          // console.log("Cart ", this.userCart);
        },
        error: (err) => {
          console.log(err);
        }
      });
    }
  }

  processData() {
    this.menuData = (this.menuData as Array<any>).map(m => {
      let cartIndex = this.userCart ? (this.userCart?.cartItems as Array<any>).findIndex(ci => ci.dishId == m.id) : -1;
      let quantity = cartIndex != -1 ? this.userCart.cartItems[cartIndex].quantity : 0;
      return {
        ...m,
        quantity: quantity
      }
    })
  }
  updateCartRequest(menu: any, isDecrement: boolean) {
    // console.log("Menu data", menu);
    let reqObj: CartItemCreateRequestType = {
      restaurantId: menu.restaurantId,
      dishId: menu.id,
      quantity: isDecrement ? -1 : 1,
    }
    // console.log("Req obj is ", reqObj);
    // return;
    this.cartService.addCartItem(reqObj).subscribe({
      next: (cart) => {
        this.cartService.getCart();
      }
    })
  }

  updateCart(menu: any, isDecrement: boolean = false) {
    if (this.userCart && this.userCart.restaurantId != menu.restaurantId) {
      Swal.fire({
        title: "Are you sure?",
        text: "Adding Item from new restaurant will remove old cart items",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Yes Proceed",
        cancelButtonText:'Cancel'
      }).then((result) => {
        if (result.isConfirmed) {
          this.updateCartRequest(menu,isDecrement);
        }
      });
      return;
    }
    else {
      this.updateCartRequest(menu, isDecrement);
    }

  }

}
