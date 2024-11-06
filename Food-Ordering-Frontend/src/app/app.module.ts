import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { CustomerHomeComponent } from './pages/customer/customer-home/customer-home.component';
import { OwnerHomeComponent } from './pages/restaurant-owner/owner-home/owner-home.component';
import { MenuComponent } from './components/restaurant-owner/menu/menu.component';
import { OrdersComponent } from './components/restaurant-owner/orders/orders.component';
import { ReviewsComponent } from './components/restaurant-owner/reviews/reviews.component';
import { LoginComponent } from './pages/shared/login/login.component';
import { ReactiveFormsModule } from '@angular/forms';
import { AuthInterceptor } from './interceptor/auth.interceptor';
import { AddUpdateRestaurantComponent } from './pages/restaurant-owner/add-update-restaurant/add-update-restaurant.component';
import { RestaurantDetailsComponent } from './pages/customer/restaurant-details/restaurant-details.component';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    CustomerHomeComponent,
    OwnerHomeComponent,
    MenuComponent,
    OrdersComponent,
    ReviewsComponent,
    LoginComponent,
    AddUpdateRestaurantComponent,
    RestaurantDetailsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule, 
    HttpClientModule,
    ReactiveFormsModule,
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true },
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }