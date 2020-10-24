import { UserDetailsService } from './../../main/Services/user-details.service';
import { DocDATA } from '../../DTO/DATA/doc-data';
import { Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { DocRemoteService } from '../../services/commService/doc-remote.service';
import { map, take } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class DocumentsService {

  constructor(private docRemoteService:DocRemoteService,private userDetailsService:UserDetailsService) { }

  ResponseSubject:{[ResponseType:string]:Subject<any>}={
    GetAllDocResponseOk:new Subject<any>()
  }

  getAllDoc(){
    this.docRemoteService.GetAllDocs({userId:this.userDetailsService.userId})
    .pipe(map(res=>[this.ResponseSubject[res.responseType],res.responseData]))
    .subscribe(([subject,data]:[Subject<any>,any])=>subject.next(data))
  }

  get onGetAllDocOk(){return this.ResponseSubject["GetAllDocResponseOk"].pipe(take(1));}

}
