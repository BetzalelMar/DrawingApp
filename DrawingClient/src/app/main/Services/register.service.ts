import { debounceTime, map, take, switchMap } from 'rxjs/operators';
import { UserRemoteService } from './user-remote.service';
import { Injectable } from '@angular/core';
import { Subject } from 'rxjs/internal/Subject';
import { ResponseB } from '../../DTO/Response/response';
import { AbstractControl, AsyncValidatorFn, ValidationErrors } from '@angular/forms';
import { Observable, Subscriber } from 'rxjs';


@Injectable()
export class RegisterService {
  constructor(private userRemoteService: UserRemoteService) {
   }
  ResponseSubject: { [responseType: string]: Subject<any> } = {
    RegisterResponseOk: new Subject<any>(),
    RegisterResponseUserExist: new Subject<any>(),
    RegisterResponsePasswordNotMatch: new Subject<any>()
  };


  Register(value: any) {
    this.userRemoteService.Register({ userId: value.userId, userName: value.userName, userPassword: value.userPassword, userConfirmPassword: value.confirmPassword })
      .pipe(map((response: ResponseB) => [this.ResponseSubject[response.responseType], response.responseData]))
      .subscribe(([subject, data]: [Subject<any>, any[]]) => subject.next(data[0]))
  }


  UserNameExist():AsyncValidatorFn {
    return (control:AbstractControl):Observable<ValidationErrors|null>=>{
      var serverResponse = this.userRemoteService.GetAllUserName()
      .pipe(map((res:ResponseB):ValidationErrors|null=>res.responseData.find(elm=>elm==control.value)?{InvalidUserName:'Name exist'}:null))
      var retval = new  Observable<ValidationErrors|null>(
        subscriber=>subscriber.next()
      ).pipe(
        take(1),
        debounceTime(5000),
        switchMap(value=>serverResponse)
      )  
      return retval
      
   }

  }


  UserIdExist():AsyncValidatorFn{
    return (control:AbstractControl):Observable<ValidationErrors|null>=>{
      var serverResponse = this.userRemoteService.GetUser({userId:control.value})
      .pipe(map((rse:ResponseB):ValidationErrors|null=>rse.responseType=='GetUserResponseInValid'?null:{InvalidUserId:'User exist'}))
      var retval = new  Observable<ValidationErrors|null>(
        subscriber=>subscriber.next()
      ).pipe(
        take(1),
        debounceTime(5000),
        switchMap(value=>serverResponse)
      )  
      return retval
      
   }

  }

  get onRegisterOk() { return this.ResponseSubject['RegisterResponseOk'] }
  get onUserExistr() { return this.ResponseSubject['RegisterResponseUserExist'] }
  get onPasswordNotMatch() { return this.ResponseSubject['RegisterResponsePasswordNotMatch'] }

}
