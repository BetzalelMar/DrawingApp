import { UserRemoteService } from './user-remote.service';
import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { map, take, tap } from 'rxjs/operators';
import { ResponseB } from 'src/app/DTO/Response/response';

@Injectable()
export class LogInService {

  constructor(private userRemoteService:UserRemoteService) { }

  ResponseSubject:{[responseType:string]:Subject<any>}={
    LogInResponseOk:new Subject<any>(),
    LogInResponseInValidUserNameOrPassword:new Subject<any>()
   };


   LogIn(value:any){
     this.userRemoteService.LogIn({userId:value.email,userPassword:value.password})
     .pipe(map((response: ResponseB) => [this.ResponseSubject[response.responseType],response]),tap(res=>console.log(res)))
     .subscribe(([subject,res]:[Subject<any>,any])=>subject.next(res))
  }

  get onLogInOk(){return this.ResponseSubject['LogInResponseOk']}
  get onLogInResponseInValidUserNameOrPassword(){return this.ResponseSubject['LogInResponseInValidUserNameOrPassword']}

}
