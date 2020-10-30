import { take } from 'rxjs/operators';
import { Marker } from './../../DTO/DATA/Marker';
import { DrawingService } from './drawing.service';
import { UserDetailsService } from './../../main/Services/user-details.service';
import { Injectable } from '@angular/core';
import {webSocket, WebSocketSubject} from 'rxjs/webSocket'
import { Subject } from 'rxjs/internal/Subject';
import { map } from 'rxjs/internal/operators/map';
import { tap } from 'rxjs/internal/operators/tap';
import { FreeDrawData } from 'src/app/DTO/DATA/free-draw-data';


@Injectable()
export class WsService {
  Stop() {
    console.log('Method not implemented.')
  }
  _subject:WebSocketSubject<unknown>
  constructor(private userDetailsService:UserDetailsService,private drawingService:DrawingService) {
   this.onMarkerDrawWs.pipe(map((data:any)=>[data.docId,data.marker]))
   .subscribe(([docId,marker]:[string,Marker])=>this.drawingService.DrawingFunc[marker.markerType](docId,marker))

   this.onFreeDrawWs.pipe(map((data:any)=>[data.docId,data]))
   .subscribe(([docId,freeDrawData]:[string,FreeDrawData])=>this.drawingService.DrawingFunc['Free'](docId,freeDrawData))

   this.onClearwWs
   .subscribe((docId)=>this.drawingService.DrawingFunc['clear'](docId))

   }

   MsgSubject:{[msgType:string]:Subject<any>}={
    WsAppFreeDrawMessage  :new Subject<any>(),
    WsAppMarkerMessage :new Subject<any>(),
    WsAppDocMessage :new Subject<any>(),
    WsAppClearMessage:new Subject<any>()
   }
   Start(){
     console.log("Service Start")
     var userId=this.userDetailsService.userId
    this._subject = webSocket(
      {url:"wss://localhost:44347/ws?id="+userId,deserializer: msg => msg})
    this._subject
    .pipe(map((res:any)=>JSON.parse(res.data)))
    .pipe(tap((res:any)=>console.log(res)),map((res:any)=>[this.MsgSubject[res.MessageType],res.Data]))
    .subscribe(([subject,data]:[Subject<any>,any])=>subject.next(data))

   }

   get onAddDocWs(){return this.MsgSubject['WsAppDocMessage']}
   get onFreeDrawWs(){return this.MsgSubject['WsAppFreeDrawMessage']}
   get onMarkerDrawWs(){return this.MsgSubject['WsAppMarkerMessage']}
   get onClearwWs(){return this.MsgSubject['WsAppClearMessage']}
}
