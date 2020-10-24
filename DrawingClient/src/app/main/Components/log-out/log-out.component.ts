import { Router } from '@angular/router';
import { LogOutService } from './../../Services/log-out.service';
import { Component, OnInit } from '@angular/core';
import { UserDetailsService } from '../../Services/user-details.service';

@Component({
  selector: 'app-log-out',
  templateUrl: './log-out.component.html',
  styleUrls: ['./log-out.component.css'],
  providers:[LogOutService]

})
export class LogOutComponent implements OnInit {

  constructor(private router:Router, private logOutService:LogOutService,private userDetailsService:UserDetailsService) { }

  ngOnInit(): void {
    this.logOutService.onLogOutOk.subscribe(res=>{
      this.userDetailsService.isLoggedIn=false;
      this.router.navigate([''])
    })
  }

  LogOut(){
    this.logOutService.LogOut(this.userDetailsService.userId);
  }
}
