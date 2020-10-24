
import { ResponseB } from './../DTO/Response/response';
import { Observable } from 'rxjs';
import { Request } from './../DTO/Request/request';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class CommService {

  constructor(private httpClient:HttpClient) { }

  httpPost(url:string,request:Request):Observable<ResponseB>{
    return this.httpClient.post<ResponseB>(url,request)
  }

  httpGet(url:string):Observable<ResponseB>{
    return this.httpClient.get<ResponseB>(url)
  }
}
