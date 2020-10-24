import { RemoveAllMarkersByDocRequest } from './../../DTO/Request/remove-all-markers-by-doc-request';
import { GetAllMarkersRequest } from './../../DTO/Request/get-all-markers-request';
import { Request } from './../../DTO/Request/request';
import { AddMarkerRequest } from './../../DTO/Request/add-marker-request';
import { CommService } from './../../services/comm.service';
import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { ResponseB } from '../../DTO/Response/response';


@Injectable({
  providedIn: 'root'
})
export class MarkerRemoteService {

  constructor(private commService:CommService) { }
  

  getAllMarkersByDocId(request:GetAllMarkersRequest):Observable<ResponseB>{
     return this.commService.httpPost('/api/GatAllMarkersByDoc',request);
  }
  
  addMarker(request:AddMarkerRequest):Observable<ResponseB>{
    return this.commService.httpPost('api/AddMarker',request)
  }

  RemoveAllMarkersByDoc(request:RemoveAllMarkersByDocRequest):Observable<ResponseB>{
    return this.commService.httpPost('api/RemoveAllMarkersByDoc',request)
  }

  updateMarker(){
    
  }

}
