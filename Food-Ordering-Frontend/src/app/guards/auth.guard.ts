import { CanActivateFn, Router } from '@angular/router';
import { AuthService } from '../services/auth.service';
import { inject } from '@angular/core';
import { jwtDecode } from "jwt-decode";
import Swal from 'sweetalert2';
import { RoutingService } from '../services/routing.service';
import { Location } from '@angular/common';

export const authGuard: CanActivateFn = (route, state) => {
  console.log("Auth Guard is Working");
  const authService = inject(AuthService)
  const router = inject(Router);
  // const routingService = inject(RoutingService);
  const location = inject(Location);
  const user = authService.getUser();
  console.log("User in Auth Guard", user);
  if (user) {
    const decodedToken: any = jwtDecode(user.token);
    const expirationDate = decodedToken.exp * 1000;
    const currentTime = new Date().getTime();

    if (expirationDate < currentTime) {
      authService.logout();
      return router.navigate(['/login'])
    }
    else {
      if (user.roles.includes('RestaurantOwner')) {
        return true;
      } else {
        // console.log("Doesn't include the role");
        // router.navigate(['/login']);
        Swal.fire({
          position: "top-end",
          icon: "warning",
          title: "Unauthorized Access",
          showConfirmButton: false,
          timer: 1500, 
          toast:true,
        });
        // let backUrl:string  = routingService.buildBackUrl(route);
        location.back();
        return false;
      }
    }
  }
  else {
    //Logout 
    authService.logout();
    Swal.fire({
      position: "top-end",
      icon: "warning",
      title: "Unauthorized. Login First!!!!",
      showConfirmButton: false,
      timer: 1500, 
      toast:true,
    });
    return router.navigate(['/login']);
  }
};


export const HomePathRedirection: CanActivateFn = (route, state) => {
    console.log("Into Home Path Redirection!!!!");
    const authService = inject(AuthService)
    const router = inject(Router)
    const user = authService.getUser();
    // if(user && route.url==='/login')
    let currentPath = route.pathFromRoot.flatMap(v => v.url).join('/')
    
    if(currentPath ==='login'){
      if(user && user.roles && user.roles.includes('RestaurantOwner'))  return router.navigate(['/restaurant-owner','home']);
      else if(user && user.roles && user.roles.includes('Customer')) return  router.navigate(['/customer','home']);
      else return true;
    }
    if(user && user.roles && user.roles.includes('RestaurantOwner') ){
      return router.navigate(['/restaurant-owner','home']);
    }
    return router.navigate(['/customer','home']);
  };