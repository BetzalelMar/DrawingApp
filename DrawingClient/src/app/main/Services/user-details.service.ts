import { LogInService } from './log-in.service';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class UserDetailsService {

  constructor(private logInService:LogInService) {
    this.logInService.onLogInOk.subscribe(res=>{
      this.userId=res.userId;
      this.userName=res.userName;
      this.isLoggedIn=true;
    })
   }

  userId:string='1333bm@gmail.com';
  userName:string=undefined;
  isLoggedIn:boolean=false;
}
