import { FormControl, Validators } from '@angular/forms';
import { UserRemoteService } from './../../../main/Services/user-remote.service';
import { SharedDocService } from '../../Services/shared-doc.service';
import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { ResponseB } from 'src/app/DTO/Response/response';

@Component({
  selector: 'app-share',
  templateUrl: './share.component.html',
  styleUrls: ['./share.component.css']
})
export class ShareComponent implements OnInit {

  constructor(@Inject(MAT_DIALOG_DATA) public docId: any,private sharedDocService :SharedDocService,public dialogRef:MatDialogRef<ShareComponent>) { }
  

  userId:FormControl
  ngOnInit(): void {


    this.sharedDocService.onShareOk.subscribe(res=>this.onClose())
    this.sharedDocService.onSharebad.subscribe((res:ResponseB)=>console.log(res.responseMessage))
    this.userId=new FormControl('',[Validators.required])
  }
  share(){
    this.sharedDocService.AddShare(this.userId.value,this.docId)
  }


  onClose(){
    this.dialogRef.close()
  }
}
