import { UserRemoteService } from './user-remote.service';
import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { map, take } from 'rxjs/operators';
import { ResponseB } from 'src/app/DTO/Response/response';

@Injectable({
  providedIn: 'root'
})
export class LogInService {

  constructor(private userRemoteService:UserRemoteService) { }

  ResponseSubject:{[responseType:string]:Subject<any>}={
    LogInResponseOk:new Subject<any>()
   };


   LogIn(value:any){
     this.userRemoteService.LogIn({userId:value.email,userPassword:value.password})
     .pipe(map((response: ResponseB) => [this.ResponseSubject[response.responseType], response.responseData]))
     .subscribe(([subject,data]:[Subject<any>,any[]])=>subject.next(data[0]))
  }

  get onLogInOk(){return this.ResponseSubject['LogInResponseOk']}

}
