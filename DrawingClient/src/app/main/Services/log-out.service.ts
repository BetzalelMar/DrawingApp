import { UserDetailsService } from './user-details.service';
import { map, take } from 'rxjs/operators';
import { Subject } from 'rxjs';
import { UserRemoteService } from './user-remote.service';
import { Injectable } from '@angular/core';
import { ResponseB } from '../../DTO/Response/response';

@Injectable()
export class LogOutService {

  constructor( private userRemoteService:UserRemoteService) { }

    ResponseSubject:{[responseType:string]:Subject<ResponseB>}={
      LogOutResponseOk:new Subject<ResponseB>()
    };


    LogOut(userId:string){
      this.userRemoteService.LogOut({userId:userId})
      .pipe(map((response: ResponseB) => [this.ResponseSubject[response.responseType], response]))
      .subscribe(([subject,res]:[Subject<any>,any])=>subject.next(res))
    }

    get onLogOutOk(){return this.ResponseSubject['LogOutResponseOk']}
}
