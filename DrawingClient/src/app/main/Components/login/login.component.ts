import { take } from 'rxjs/operators';
import { ResponseB } from 'src/app/DTO/Response/response';
import { UserDetailsService } from 'src/app/main/Services/user-details.service';
import { Router } from '@angular/router';
import { LogInService } from './../../Services/log-in.service';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { map } from 'rxjs/internal/operators/map';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
  providers:[LogInService]
})
export class LoginComponent implements OnInit {

  constructor(@Inject(MAT_DIALOG_DATA) public data: any,
                private routr:Router,
                private uerDetailsService:UserDetailsService, 
                private logInService:LogInService,
                public dialogRef: MatDialogRef<LoginComponent>) {
   }
  LogInForm:FormGroup;
  hide = true;
  
  ngOnInit(): void {
    this.LogInForm=new FormGroup({
      email:new FormControl(this.data['userId'],[Validators.email,Validators.required]),
      password:new FormControl(this.data['userPassword'],[Validators.required])
    }
    )
    this.logInService.onLogInOk
    .pipe(map((res:ResponseB)=>res.responseData[0]),take(1))
    .subscribe(res=>{
            this.uerDetailsService.updateDetails(res.userId,res.userName)
            this.onClose();
            this.routr.navigate(['docs']);})
    this.logInService.onLogInResponseInValidUserNameOrPassword.subscribe(res=>console.log(res))
  }

  onSubmit(){
    if(!this.LogInForm.valid)return;
    this.logInService.LogIn(this.LogInForm.value);
  }

  getErrorMessage(controlName:string){
    return this.LogInForm.controls[controlName].hasError('required')?'You must enter a value'
    :this.LogInForm.controls[controlName].hasError('email') ?'Not a valid email':'';
  }
  get email(){return this.LogInForm.controls['email']}
  get password(){return this.LogInForm.controls['password']}


  onClose(){
    this.dialogRef.close()
  }
}
