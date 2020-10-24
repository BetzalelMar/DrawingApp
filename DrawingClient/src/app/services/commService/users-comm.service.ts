import { SignUpResponse } from '../../DTO/Response/SignUpResponse/sign-up-response';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { SignUpRequest } from '../../DTO/Request/SignUpRequest';
import { Observable } from 'rxjs';
import { tap,map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class UsersCommService {

  constructor(private httpClient:HttpClient) { }

  SignUp(request:SignUpRequest):Observable<SignUpResponse>{
    return this.httpClient.post<SignUpResponse>("api/SignUp/SignUp",request).pipe(tap(res=>console.log(res)));
  }
}
