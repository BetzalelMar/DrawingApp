
import { ResponseB } from './../DTO/Response/response';
import { Observable, Subject } from 'rxjs';
import { Request } from './../DTO/Request/request';
import { HttpClient, HttpHandler } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class CommService {

  constructor(private httpClient: HttpClient) { }

  httpPost(url: string, request: Request): Observable<ResponseB> {
    var retval = new Subject<ResponseB>()
    this.httpClient.post<ResponseB>(url, request)
    .subscribe((res: ResponseB) => {
        if (res.responseType == 'AppResponseError'){
          this.handlerErr(res)
        }
      else
       retval.next(res)
      })
    return retval;
    //return  this.httpClient.post<ResponseB>(url, request);
  }

  httpGet(url: string): Observable<ResponseB> {
    return this.httpClient.get<ResponseB>(url)
  }



  handlerErr(res:ResponseB){
    console.log(res.responseMessage)
          //todo
  }
}
