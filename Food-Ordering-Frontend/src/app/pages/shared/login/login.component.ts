import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { LoginResponse } from 'src/app/models/response.model';
import { AuthService } from 'src/app/services/auth.service';
import { CartService } from 'src/app/services/cart.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})

export class LoginComponent implements OnInit {
  formModel:FormGroup;
  constructor(private authService: AuthService, private fb:FormBuilder,
     private router:Router, private cartService:CartService) {
    this.formModel=this.fb.group({
      Email:['',Validators.compose([Validators.required,Validators.email])],
      Password:['',Validators.compose([Validators.required,Validators.nullValidator])]
    })
  }

  ngOnInit(): void {

  }

  onSubmit(){
    this.authService.login(this.formModel.value).subscribe({
      next:(response:LoginResponse)=>{
        this.authService.setUser({
          userId : response.userId,
          email: response.email,
          roles: response.roles,
          name: response.name,
          token : response.jwtToken, 
        });
        if(response.roles.includes('Customer')){
          this.cartService.getCart();
          this.router.navigateByUrl('/customer/home')
        }
        else{
          this.router.navigateByUrl('/restaurant-owner/home');
        }
      },
      error:(err)=>{console.log(err);}
    });
    
  }
}
