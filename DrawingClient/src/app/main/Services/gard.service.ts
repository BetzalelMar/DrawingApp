import { Observable } from 'rxjs';
import { UserDetailsService } from './user-details.service';
import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { map } from 'rxjs/internal/operators/map';

@Injectable({
  providedIn: 'root'
})
export class GardService implements CanActivate {

  constructor(public router :Router,private userDetailsService:UserDetailsService) { }
  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot):Observable<boolean> {
    console.log('in gard service')
    var isLog;
    return this.userDetailsService.IsLoggedIn().pipe(
      map(res=>{if(res){return true} else{this.router.navigate(['/']); return false}})

    )

  }
}
