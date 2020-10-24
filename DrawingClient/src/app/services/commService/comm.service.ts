import { SignUpResponse } from '../../DTO/Response/SignUpResponse/sign-up-response';
import { Injectable } from '@angular/core';
import { SignUpRequest } from '../../DTO/Request/SignUpRequest';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export abstract class CommService {
  abstract SignUp(request:SignUpRequest):Observable<SignUpResponse>;

  constructor() { }
}
