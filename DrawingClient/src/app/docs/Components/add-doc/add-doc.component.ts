import { AddDocumentService } from '../../Services/add-document.service';
import { Component, OnInit } from '@angular/core';
import { FormGroup, Validators, FormControl } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-add-doc',
  templateUrl: './add-doc.component.html',
  styleUrls: ['./add-doc.component.css'],
  providers:[AddDocumentService]
})
export class AddDocComponent implements OnInit {

  // constructor(private dialogRef: MatDialogRef<AddDocComponent>, private fb: FormBuilder, private cd: ChangeDetectorRef, private addDocService: AddDocumentService) { }
  constructor(private dialogRef: MatDialogRef<AddDocComponent>, private addDocService: AddDocumentService) { }

  AddDocForm: FormGroup
  imageUrl: string;
  resImag: string;
  ngOnInit(): void {
    this.AddDocForm = new FormGroup({
      docName: new FormControl('', [Validators.required]),
      file: new FormControl('',[Validators.required])
    }
    )
    this.addDocService.onAddDocOk.subscribe(() =>
     this.onClose()) // this.dialogRef.close({add:true,data:data}))
  }

  onFileChange(evt) {
    this.addDocService.upload(evt).subscribe(file => {
      this.AddDocForm.patchValue({ file: file });
      //this.cd.markForCheck();
      this.imageUrl = file;
    }
    )
  }
  getErrorMessage(controlName:string){
   return this.AddDocForm.controls[controlName].hasError('required')?'You must enter a value':''
  }

  onSubmit(): void {
    this.addDocService.addDoc(this.AddDocForm.value)
    .subscribe(res=>this.onClose())
  }
  onClose(){
    this.dialogRef.close({add:false})
  }

  get docName() { return this.AddDocForm.controls.docName }


}
