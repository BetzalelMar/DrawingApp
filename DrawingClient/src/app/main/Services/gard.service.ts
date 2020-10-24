import { UserDetailsService } from './user-details.service';
import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class GardService implements CanActivate {

  constructor(public router :Router,private userDetailsService:UserDetailsService) { }
  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
    console.log('in gard service')
    if(!this.userDetailsService.isLoggedIn){
      this.router.navigate([''])
      return false;
    }

    return true;
  }
}
