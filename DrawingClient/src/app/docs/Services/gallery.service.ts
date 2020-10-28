import { SharedDocRemoteService } from './../Services/shared-doc-remote.service';
import { map, take } from 'rxjs/operators';
import { ResponseB } from './../../DTO/Response/response';
import { DocRemoteService } from './doc-remote.service';
import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { DocDATA } from '../../DTO/DATA/doc-data';
import { UserDetailsService } from 'src/app/main/Services/user-details.service';

@Injectable(
)
export class GalleryService {

  constructor(private userDetailsService: UserDetailsService,private sharedDocRemoteService:SharedDocRemoteService, private docRemoteService: DocRemoteService) { }

  ResponseSubject: { [responseType: string]: Subject<any> } = {
    GetAllDocResponseOk: new Subject<any>()
    }


  getAllDocs() {
    var userId = this.userDetailsService.userId
    this.docRemoteService.GetAllDocs({ userId: userId })
      .pipe(map((response: ResponseB) => [this.ResponseSubject[response.responseType], response.responseData]))
      .subscribe(([subject,data]:[Subject<any>,any[]])=>subject.next(data))
  }

  get onGetAllDocResponseOk(){return this.ResponseSubject['GetAllDocResponseOk']}
  
}
