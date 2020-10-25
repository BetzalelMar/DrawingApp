import { SharedDocRemoteService } from './shared-doc-remote.service';
import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { map } from 'rxjs/operators';
import { ResponseB } from 'src/app/DTO/Response/response';

@Injectable({
  providedIn: 'root'
})
export class SharedDocService {

  constructor(private sharedDocRemoteService:SharedDocRemoteService) { }


  ResponseSubject: { [responseType: string]: Subject<any> } = {
    AddSharedBadResponse: new Subject<any>(),
    AddSharedResponseOk: new Subject<any>(),
    RemoveSharedResponseOk: new Subject<any>()
  }
 AddShare(userId:any,docId:string){
   var parm={sharedData:{userId:userId,docId:docId}}
   this.sharedDocRemoteService.AddShared(parm)
   .pipe(map((response: ResponseB) => [this.ResponseSubject[response.responseType], response.responseData]))
   .subscribe(([subject, data]: [Subject<any>, any[]]) => subject.next(data[0]))
}

 get onShareOk(){return this.ResponseSubject['AddSharedResponseOk']}
 get onSharebad(){return this.ResponseSubject['AddSharedBadResponse']}

}
