import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import { User } from 'src/app/models/generic.model';
import { AuthService } from 'src/app/services/auth.service';
import { CartService } from 'src/app/services/cart.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {
  userCart:any;
  user:User|undefined;

  constructor(private authService: AuthService, 
    private router:Router, private fb:FormBuilder,
    private cartService:CartService) {
  
  }

  ngOnInit(): void {
    this.authService.user$().subscribe(user=>{
      this.user = user;
    });
    this.cartService.userCart$().subscribe({
      next:(cart)=>{
        this.userCart = cart;
      }
    })
  }

  logout(){
    this.authService.logout();
    console.log("Token Removed");
    this.router.navigate(['/user','home'])
  }

}
