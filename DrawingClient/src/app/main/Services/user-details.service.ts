import { UserRemoteService } from './user-remote.service';
import { LogInService } from './log-in.service';
import { Injectable } from '@angular/core';
import { ResponseB } from 'src/app/DTO/Response/response';
import { map } from 'rxjs/internal/operators/map';
import { Observable } from 'rxjs/internal/Observable';
import { Subject } from 'rxjs/internal/Subject';

@Injectable({
  providedIn: 'root'
})
export class UserDetailsService {

  constructor(private userRemoteService: UserRemoteService) {
    this.userId=localStorage.getItem('userId')
  }
  userId: string = '';
  userName: Subject<string>=new Subject<string>();
  

  updateDetails(userId:string,userName:string){
    localStorage.setItem('userId',userId)
    this.userId = userId;
    this.userName.next(userName);
  }

  IsLoggedIn():Subject<boolean>{
    var retval = new Subject<boolean>();
    this.userRemoteService.GetUser({ userId: this.userId })
      .subscribe((res: ResponseB) => {
        if (res.responseType == 'GetUserResponseOk') {
          var data = res.responseData[0]
          this.updateDetails(data.userId,data.userName);
          retval.next(data.isLoggedIn=='1')
        }
        else{
          retval.next(false)
        }
      })
    return retval;
  }
}
