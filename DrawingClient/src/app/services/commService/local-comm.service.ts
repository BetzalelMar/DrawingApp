import { UsersCommService } from './users-comm.service';
import { Injectable } from '@angular/core';
import { CommService } from './comm.service';
import { SignUpRequest } from '../../DTO/Request/SignUpRequest';
import { Observable } from 'rxjs';
import { SignUpResponse } from '../../DTO/Response/SignUpResponse/sign-up-response';

@Injectable({
  providedIn: 'root'
})
export class LocalCommService implements CommService {

  constructor(private userCommService:UsersCommService) { }
  SignUp(request: SignUpRequest): Observable<SignUpResponse> {
    return this.userCommService.SignUp(request)
  }
}
