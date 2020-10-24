import { GetAllDocRequest } from './../../DTO/Request/get-all-doc-request';
import { AddDocRequest } from './../../DTO/Request/add-doc-request';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ResponseB } from 'src/app/DTO/Response/response';
@Injectable({
  providedIn: 'root'
})
export class DocRemoteService {
  constructor(private httpClient:HttpClient) { }

  AddDocument(request:AddDocRequest):Observable<any>{
    
    return this.httpClient.post<ResponseB>("api/AddDoc",request);
  }

  GetAllDocs(request:GetAllDocRequest):Observable<ResponseB>
  {
    return this.httpClient.post<ResponseB>("api/GetAllDocs",request);
  }
}
