import { UserDetailsService } from './../../main/Services/user-details.service';
import { DocDATA } from '../../DTO/DATA/doc-data';
import { Injectable } from '@angular/core';
import { Observable, Subject} from 'rxjs';
import { DocRemoteService } from './doc-remote.service';
import { take, map } from 'rxjs/operators';
import { ResponseB } from 'src/app/DTO/Response/response';

@Injectable()
export class AddDocumentService {

  constructor(private documentRemoteService:DocRemoteService,private userDetailsService:UserDetailsService){ }

  ResponseSubject:{[ResponseType:string]:Subject<any>}={
    AddDocResponseOk:new Subject<any>()
  }

  upload(event):Observable<any> {
    let file = event.target.files[0];
    var subject=new Subject<any>();
    if (file) {
      var reader = new FileReader();
      reader.onload = (readerEvt)=> {
        subject.next("data:image/png;base64,"+ btoa(readerEvt.target.result.toString()))
       };
      reader.readAsBinaryString(file);
      return subject;
    }
  }

  addDoc(value:any):Observable<ResponseB>{
    var param={ownerId:this.userDetailsService.userId,docName:value.docName,docUrl:value.file}
    return this.documentRemoteService.AddDocument(param)
    // .pipe(map(res=>[res,this.ResponseSubject[res.responseType]]))
    // .subscribe(([res,subject])=>subject.next(res.responseData[0]))
  }

  get onAddDocOk(){return this.ResponseSubject["AddDocResponseOk"]}
}
