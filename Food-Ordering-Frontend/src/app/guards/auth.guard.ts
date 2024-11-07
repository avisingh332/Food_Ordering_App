import { CanActivateFn, Router } from '@angular/router';
import { AuthService } from '../services/auth.service';
import { inject } from '@angular/core';
import { jwtDecode } from "jwt-decode";
import Swal from 'sweetalert2';

export const authGuard: CanActivateFn = (route, state) => {
  const authService = inject(AuthService)
  const router = inject(Router)
  const user = authService.getUser();
  if (user) {
    const decodedToken: any = jwtDecode(user.token);
    const expirationDate = decodedToken.exp * 1000;
    const currentTime = new Date().getTime();

    if (expirationDate < currentTime) {
      authService.logout();
      return router.navigate(['/login'])
    }
    else {
      if (user.roles.includes('Organizer')) {
        return true;
      } else {
        router.navigate(route.url);
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