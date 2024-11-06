import { Component, NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MenuComponent } from './components/restaurant-owner/menu/menu.component';
import { OrdersComponent } from './components/restaurant-owner/orders/orders.component';
import { ReviewsComponent } from './components/restaurant-owner/reviews/reviews.component';
import { OwnerHomeComponent } from './pages/restaurant-owner/owner-home/owner-home.component';
import { LoginComponent } from './pages/shared/login/login.component';
import { CustomerHomeComponent } from './pages/customer/customer-home/customer-home.component';
import { AddUpdateRestaurantComponent } from './pages/restaurant-owner/add-update-restaurant/add-update-restaurant.component';
import { RestaurantDetailsComponent } from './pages/customer/restaurant-details/restaurant-details.component';


const routes: Routes = [
  {path:'', pathMatch:'full', redirectTo:'restaurant-owner/home/menu'},
  {path:'login', component:LoginComponent},
  {path:'restaurant-owner', children:[
    {path:'home', component:OwnerHomeComponent, children:[
      {path: '', redirectTo: 'menu', pathMatch: 'full' },
      {path:'menu', component:MenuComponent},
      {path:'orders', component:OrdersComponent},
      {path:'reviews', component:ReviewsComponent}
    ]}, 
    {path:'add-update', component:AddUpdateRestaurantComponent},
  ]}, 
  {path:'customer', children:[
    {path:'home', component:CustomerHomeComponent},
    {path:'restaurant/:id',component: RestaurantDetailsComponent}
  ]}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
