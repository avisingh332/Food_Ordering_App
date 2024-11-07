import { Component, NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MenuComponent } from './components/shared/menu/menu.component';
import { OrdersComponent } from './components/shared/orders/orders.component';
import { ReviewsComponent } from './components/shared/reviews/reviews.component';
import { OwnerHomeComponent } from './pages/restaurant-owner/owner-home/owner-home.component';
import { LoginComponent } from './pages/shared/login/login.component';
import { CustomerHomeComponent } from './pages/customer/customer-home/customer-home.component';
import { AddUpdateRestaurantComponent } from './pages/restaurant-owner/add-update-restaurant/add-update-restaurant.component';
import { RestaurantDetailsComponent } from './pages/customer/restaurant-details/restaurant-details.component';
import { HomePathRedirection } from './guards/auth.guard';


const routes: Routes = [
  {path:'', canActivate:[HomePathRedirection], component:CustomerHomeComponent},
  {path:'login', component:LoginComponent, canActivate:[HomePathRedirection]},
  {path:'restaurant-owner', children:[
    {path:'home', component:OwnerHomeComponent, children:[
      {path: '', redirectTo: 'orders', pathMatch: 'full' },
      {path:'menu', component:MenuComponent},
      {path:'orders', component:OrdersComponent},
      {path:'reviews', component:ReviewsComponent}
    ]}, 
    {path:'add-update', component:AddUpdateRestaurantComponent},
    {path:'add-update/:id', component:AddUpdateRestaurantComponent},
  ]}, 
  {path:'customer', children:[
    {path:'home', component:CustomerHomeComponent},
    {path:'restaurant/:id',component: RestaurantDetailsComponent,
      children:[
        {path:'', redirectTo:'menu',pathMatch:'full'},
        {path:'menu', component:MenuComponent},
        {path:'reviews', component:ReviewsComponent},
      ]
    }
  ]}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
