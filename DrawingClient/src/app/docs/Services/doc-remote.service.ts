import { GetAllDocRequest } from '../../DTO/Request/get-all-doc-request';
import { AddDocRequest } from '../../DTO/Request/add-doc-request';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ResponseB } from 'src/app/DTO/Response/response';
import { CommService } from 'src/app/services/comm.service';
@Injectable({
  providedIn: 'root'
})
export class DocRemoteService {
  constructor(private commService:CommService) { }

  AddDocument(request:AddDocRequest):Observable<any>{
    
    return this.commService.httpPost("api/AddDoc",request);
  }

  GetAllDocs(request:GetAllDocRequest):Observable<ResponseB>
  {
    return this.commService.httpPost("api/GetAllDocs",request);
  }
}
