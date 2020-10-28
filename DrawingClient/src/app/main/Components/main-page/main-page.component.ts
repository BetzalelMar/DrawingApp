import { UserDetailsService } from 'src/app/main/Services/user-details.service';
import { tap } from 'rxjs/operators';
import { MatDialog } from '@angular/material/dialog';
import { Component, OnInit } from '@angular/core';
import { LoginComponent } from '../login/login.component';
import { RegisterComponent } from '../register/register.component';
import { AddDocComponent } from 'src/app/docs/Components/add-doc/add-doc.component';
@Component({
  selector: 'app-main-page',
  templateUrl: './main-page.component.html',
  styleUrls: ['./main-page.component.css']
})
export class MainPageComponent implements OnInit {

  constructor(private dialog:MatDialog,private userDetailsService:UserDetailsService) { }
  userName:string
  ngOnInit(): void {
    this.userDetailsService.userName.subscribe(res=>this.userName=res)
  }
  onLogInDialog(parm={userId:'',userPassword:''}){
    this.dialog.open(LoginComponent,{
      disableClose :true,
      data:parm
    })
  }
  onRegisterDialog(){
    this.dialog.open(RegisterComponent,{
      disableClose :true
    })
    .afterClosed()
    .subscribe(data=>{if(data)this.onLogInDialog(data)})
  }    
  

}
