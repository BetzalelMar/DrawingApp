import { GetUserRequest } from './../../DTO/Request/get-user-request';
import { RegisterRequest } from './../../DTO/Request/register-request';
import { LogInRequest } from './../../DTO/Request/log-in-request';
import { LogOutRequest } from './../../DTO/Request/log-out-request';
import { CommService } from './../../services/comm.service';
import { ResponseB } from '../../DTO/Response/response';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class UserRemoteService {

  constructor(private commService:CommService) { }

LogIn(request:LogInRequest):Observable<ResponseB>{
  return this.commService.httpPost('api/LogIn',request);
}

 LogOut(request:LogOutRequest):Observable<ResponseB>{
   return this.commService.httpPost('api/LogOut',request);
 }

 Register(request:RegisterRequest):Observable<ResponseB>{
  return this.commService.httpPost('api/Register',request);
}

GetUser(request:GetUserRequest):Observable<ResponseB>{
  return this.commService.httpPost('api/GetUser',request)
}

GetAllUserName():Observable<ResponseB>{
  return this.commService.httpGet('api/GetUser')
}

}
