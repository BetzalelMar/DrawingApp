import { Marker } from './../../DTO/DATA/Marker';
import { DrawingService } from './drawing.service';
import { UserDetailsService } from './../../main/Services/user-details.service';
import { Injectable } from '@angular/core';
import {webSocket, WebSocketSubject} from 'rxjs/webSocket'
import { Subject } from 'rxjs/internal/Subject';
import { map } from 'rxjs/internal/operators/map';
import { tap } from 'rxjs/internal/operators/tap';


@Injectable()
export class WsService {
  Stop() {
    console.log('Method not implemented.')
  }
  _subject:WebSocketSubject<unknown>
  constructor(private userDetailsService:UserDetailsService,private drawingService:DrawingService) {
   this.MsgSubject['MarkerDraw'].pipe(map((data:any)=>[data.docId,data.marker]))
   .subscribe(([docId,marker]:[string,Marker])=>this.drawingService.DrawingFunc[marker.markerType](docId,marker))
   
   }

   MsgSubject:{[msgType:string]:Subject<any>}={
    FreeDraw     :new Subject<any>(),
    MarkerDraw :new Subject<any>(),
    AddDoc :new Subject<any>()
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

   get onAddDocWs(){return this.MsgSubject['AddDoc']}
   get onFreeDrawWs(){return this.MsgSubject['FreeDraw']}
   get onMarkerDrawWs(){return this.MsgSubject['MarkerDraw']}
}
