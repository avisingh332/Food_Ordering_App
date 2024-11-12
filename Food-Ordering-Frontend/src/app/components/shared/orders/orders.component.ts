import { Component, OnInit } from '@angular/core';
import { OrderStatus } from 'src/app/models/generic.model';
import { OrderService } from 'src/app/services/order.service';
import { RestaurantService } from 'src/app/services/restaurant.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-orders',
  templateUrl: './orders.component.html',
  styleUrls: ['./orders.component.css']
})
export class OrdersComponent implements OnInit {
  orders:any;
  selectedOrder:any=null;
  allStatus = OrderStatus;
  constructor(private restaurantService:RestaurantService, private orderService:OrderService) {
  }
  ngOnInit(): void {
    this.processData();
  }
  processData(){
    this.orders = this.restaurantService.restaurantDetails.orders;
    this.orders = (this.orders as Array<any>).map(o=>{
      return {
        ...o, 
        orderStatus:(o.orderStatus as OrderStatus)
      }
    })
  }
  
  openOrderDetails(order:any){
    // console.log("button is clicked with order details", order);
    let orderTotal = (order.orderItems as Array<any>).reduce((sum, oi)=>{
      return sum + oi.quantity * oi.menu.price;
    },0);
    this.selectedOrder = {
      ...order, 
      orderTotal: orderTotal
    }
    console.log("Selected Order ", this.selectedOrder);
  }

  updateOrderStatus(status:OrderStatus){
    if(this.selectedOrder!=null){
      this.orderService.updateOrderStatus(this.selectedOrder.id, status).subscribe({
        next:(resp)=>{
          this.restaurantService.getAllRestaurants().subscribe({
            next:(resp)=>{
              this.restaurantService.restaurantDetails  =resp[0];
              this.processData();
            }
          })
          Swal.fire({
            position: "top-end",
            icon: "success",
            title: "Order Status Updated",
            showConfirmButton: false,
            timer: 1500, 
            toast:true,
          });
        },
        error:(err)=>{
          console.log(err);
        }
      })
    }
  }
}
