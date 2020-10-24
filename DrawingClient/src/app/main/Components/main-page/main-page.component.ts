import { tap } from 'rxjs/operators';
import { LogOutComponent } from './../log-out/log-out.component';
import { MatDialog } from '@angular/material/dialog';
import { Component, OnInit } from '@angular/core';
import { LoginComponent } from '../login/login.component';
import { RegisterComponent } from '../register/register.component';
import { map } from 'rxjs/internal/operators/map';
import { AddDocComponent } from 'src/app/docs/Components/add-doc/add-doc.component';

@Component({
  selector: 'app-main-page',
  templateUrl: './main-page.component.html',
  styleUrls: ['./main-page.component.css']
})
export class MainPageComponent implements OnInit {

  constructor(private dialog:MatDialog) { }

  ngOnInit(): void {
  }
  onLogInDialog(parm={userId:'',userPassword:''}){
    this.dialog.open(LoginComponent,{
      data:parm
    })
  }
  onRegisterDialog(){
    this.dialog.open(RegisterComponent,{
      disableClose :true
    })
    .afterClosed()
    .pipe(tap(data=>console.log(data)))
    .subscribe(data=>{if(data)this.onLogInDialog(data)})
  }

  onAddDialog(){
    this.dialog.open(AddDocComponent)
  }

}
