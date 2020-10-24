import { MatDialogRef } from '@angular/material/dialog';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { RegisterService } from './../../Services/register.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
  providers:[RegisterService]
})
export class RegisterComponent implements OnInit {

  constructor(private registerService: RegisterService, private dialogRef:MatDialogRef<RegisterComponent>) { }
  RegisterForm: FormGroup
  hide = true;
  ngOnInit(): void {
    this.RegisterForm = new FormGroup({
      userId: new FormControl('', [Validators.required, Validators.email], this.registerService.UserIdExist()),
      userName: new FormControl('', [Validators.required], this.registerService.UserNameExist()),
      userPassword: new FormControl('', [Validators.required]),
      confirmPassword: new FormControl('', [Validators.required])
    })

    this.registerService.onRegisterOk.subscribe(()=>{
      this.dialogRef.close({userId:this.userId.value,userPassword:this.userPassword.value})
      })
  }
  getErrorMessage(controlName:string){
    var control=this.RegisterForm.controls[controlName]
    return this.RegisterForm.controls[controlName].hasError('required')?'You must enter a value'
    :this.RegisterForm.controls[controlName].hasError('email') ?'Not a valid email'
    :this.RegisterForm.controls[controlName].hasError('InvalidUserName')?control.errors.InvalidUserName
    :this.RegisterForm.controls[controlName].hasError('InvalidUserId')?control.errors.InvalidUserId
    :this.RegisterForm.controls[controlName].hasError('pattern')?'Password & Confirm Password does'
    :''
    
  }


  get userId() { return this.RegisterForm.controls['userId']; }
  get userName() { return this.RegisterForm.controls['userName']; }
  get userPassword() { return this.RegisterForm.controls['userPassword']; }
  get confirmPassword() { return this.RegisterForm.controls['confirmPassword']; }

  onSubmit() {
    if (this.RegisterForm.valid)
      this.registerService.Register(this.RegisterForm.value)
  }

  onClose(){
    this.dialogRef.close()
  }

}
