import { RemoveAllMarkersByDocRequest } from './../../DTO/Request/remove-all-markers-by-doc-request';
import { ResponseB } from 'src/app/DTO/Response/response';
import { Observable, Subject } from 'rxjs';
import { Injectable } from '@angular/core';
import { MarkerRemoteService } from './marker-remote.service';
import { Marker } from 'src/app/DTO/DATA/Marker';
import { map, tap } from 'rxjs/operators';
import { MarkerData } from 'src/app/DTO/DATA/marker-data';
import { UserDetailsService } from 'src/app/main/Services/user-details.service';
// @Injectable({
//   providedIn: 'root'
// })
@Injectable()
export class MarkerService {

  constructor(private markerRemoteService: MarkerRemoteService, private userDetailsService: UserDetailsService) { }
  
  ResponseSubject:{[responseType:string]:Subject<any>}={
    AddMarkerBadResponse :new Subject<any>(),
    AddMarkerResponseOk:new Subject<any>(),
    GetAllMarkersByDocResponseOk:new Subject<Array<MarkerData>>(),
    GetAllMarkersByDocBadResponse:new Subject<any>(),
    RemoveMarkerBadResponse:new Subject<any>(),
    RemoveMarkerResponseOk:new Subject<any>(),
    RemoveAllMarkersByDocBadResponse:new Subject<any>(),
    RemoveAllMarkersByDocResponseOk:new Subject<any>()
  }


  getAllMarkersByDocId(docId: string) {
    var param={docId:docId};
    this.markerRemoteService.getAllMarkersByDocId(param)
    .pipe(map((response: ResponseB) => [this.ResponseSubject[response.responseType], response.responseData]))
    .subscribe(([subject,data]:[Subject<any>,MarkerData[]])=>subject.next(data))
  }

  addMarker(docId: string, Marker: Marker){
    var param = {
      markerData: {
        docId: docId,
        marker: {
          markerType: Marker.markerType,
          markerLocation: { pos: Marker.markerLocation.pos, radius: Marker.markerLocation.radius },
          markerColor: Marker.markerColor,
          markerId: null,
          originScreen:Marker.originScreen

        },
        userId: this.userDetailsService.userId
      }
    }
    this.markerRemoteService.addMarker(param)
    .pipe(map((response: ResponseB) => [this.ResponseSubject[response.responseType], response.responseData[0]]))
    .subscribe(([subject,data]:[Subject<any>,MarkerData])=>subject.next(data))

  }

  RemoveAllMarkersByDoc(docId:string){
    this.markerRemoteService.RemoveAllMarkersByDoc({docId:docId})
    .pipe(map((response: ResponseB) => [this.ResponseSubject[response.responseType], response.responseData[0]]))
    .subscribe(([subject,data]:[Subject<any>,MarkerData])=>subject.next(data))

  }

  updateMarker() {

  }

  get onAddMarkerOk(){return this.ResponseSubject['AddMarkerResponseOk']}
  get onGetAllMarkersOk(){return this.ResponseSubject['GetAllMarkersByDocResponseOk']}
  get onRemoveAllMarkersByDocOk(){return this.ResponseSubject['RemoveAllMarkersByDocResponseOk']}

}
