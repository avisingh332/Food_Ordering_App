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
        this.isLoading = true;
        this.cartService.userCart$().subscribe({
          next:(cart)=>{
            this.userCart = cart;
            this.processData();
            this.isLoading = false;
          },
          error:(err)=>{
            console.log(err);
          }
        })
      },
      error:(err)=>{
        console.log(err);
      }
    })
    // combineLatest([this.restaurantService.getRestaurantById(id).pipe(
    //   tap(restaurant => {
    //     this.restaurantDetails = restaurant
    //   })),
    // this.cartService.userCart$().pipe(
    //   tap(cart=>{
    //     console.log("Cart is Updated!!!!");
    //     this.userCart = cart;
    //     if(!this.isLoading){
    //       this.processData();
    //     }
    //   })
    // )
    // ]).subscribe({
    //   next: ([restaurant, cart]) => {
    //     // this.restaurantDetails = restaurant;
    //     // this.userCart = cart;
    //     this.processData();
    //   },
    //   error: (err) => {
    //     console.log("There is some Error!!!!");
    //     console.log(err);
    //   }
    // })

    // this.restaurantService.getRestaurantById(id).subscribe({
    //   next:(resp)=>{
    //     this.restaurantDetails = resp;
    //     this.isLoading= false;
    //   }, 
    //   error:(err)=>{
    //     console.log(err);
    //   }
    // })
  }

  processData() {
    let menus = this.restaurantDetails.menus as Array<any>;
    this.restaurantDetails.menus = menus.map(m => {
      let cartIndex = (this.userCart.cartItems as Array<any>).findIndex(ci=> ci.dishId == m.id);
      let quantity = cartIndex!=-1 ? this.userCart.cartItems[cartIndex].quantity : 0;
      return {
        ...m,
        quantity: quantity
      }
    })
    // console.log("Menu data is ", this.restaurantDetails.menus);
    // console.log("Cart itemss", this.userCart.cartItems);
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
