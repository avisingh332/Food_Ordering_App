import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import { User } from 'src/app/models/generic.model';
import { CartItemCreateRequestType } from 'src/app/models/request.model';
import { AuthService } from 'src/app/services/auth.service';
import { CartService } from 'src/app/services/cart.service';
import { OrderService } from 'src/app/services/order.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {
  userCart: any;
  user: User | undefined;
  isLoading: boolean = true;
  constructor(private authService: AuthService,
    private router: Router, private fb: FormBuilder,
    private orderService: OrderService,
    private cartService: CartService) {

  }

  ngOnInit(): void {
    this.authService.user$().subscribe(user => {
      this.user = user;
    });
    this.cartService.userCart$().subscribe({
      next: (cart) => {
        this.userCart = cart;
        if(cart!=null){
          this.processCartData();
        }
        this.isLoading = false;
      }

    })
  }
  logout() {
    this.authService.logout();
    console.log("Token Removed");
    this.router.navigate(['/user', 'home'])
  }

  processCartData() {
    let cartTotal = (this.userCart.cartItems as Array<any>).reduce((sum, ci) => {
      return sum + ci.quantity * ci.menu.price;
    }, 0);

    this.userCart = {
      ...this.userCart,
      cartTotal: cartTotal,
    }

  }


  updateCart(menu: any, isDecrement: boolean = false) {
    let reqObj: CartItemCreateRequestType = {
      restaurantId: menu.restaurantId,
      dishId: menu.id,
      quantity: isDecrement ? -1 : 1,
    }
    // return;
    this.cartService.addCartItem(reqObj).subscribe({
      next: (cart) => {
        this.cartService.getCart();
      }
    })
  }

  placeOrder() {
    if(!this.userCart || this.userCart && this.userCart.cartItems.length==0 ){
      Swal.fire({
        position: "top-end",
        icon: "error",
        title: "Please Add Items to cart to Proceed",
        showConfirmButton: false,
        timer: 1500, 
        toast:true,
      });
      return;
    }
    this.orderService.placeOrder(this.userCart.id).subscribe({
      next: (resp) => {
        Swal.fire({
          position: "top-end",
          icon: "success",
          title: "Order Placed Successfully",
          showConfirmButton: false,
          timer: 1500, 
          toast:true,
        });
        console.log(resp);
        this.cartService.getCart();
      }
    })
  }
  
}
