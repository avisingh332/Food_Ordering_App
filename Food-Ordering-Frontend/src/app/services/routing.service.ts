import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class RoutingService {

  constructor() { }
  
  buildBackUrl(routeSnapshot: ActivatedRouteSnapshot): string {
    let path = '';
  
    while (routeSnapshot) {
      if (routeSnapshot.url && routeSnapshot.url.length) {
        path = `/${routeSnapshot.url.map(segment => segment.path).join('/')}${path}`;
      }
      routeSnapshot = routeSnapshot.parent as ActivatedRouteSnapshot;
    }
  
    return path;
  }
}
