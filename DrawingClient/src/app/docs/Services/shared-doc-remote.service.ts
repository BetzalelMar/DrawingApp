import { AddSharedRequest } from '../../DTO/Request/add-shared-request';
import { Observable } from 'rxjs';
import { CommService } from './../../services/comm.service';
import { Injectable } from '@angular/core';
import { ResponseB } from 'src/app/DTO/Response/response';
import { GetAllSharedRequest } from '../../DTO/Request/get-all-shared-request';


@Injectable({
  providedIn: 'root'
})
export class SharedDocRemoteService {

  constructor(private commService:CommService ) { }

  AddShared(request:AddSharedRequest):Observable<ResponseB>
  {
    return this.commService.httpPost('/api/AddShared',request)
  }
  GetAllSharedDoc(request:GetAllSharedRequest):Observable<ResponseB>
  {
    return this.commService.httpPost('api/GetAllShared',request)
  }


}
