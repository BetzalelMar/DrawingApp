import { WsService } from './../../Services/ws.service';
import { DocDATA } from '../../../DTO/DATA/doc-data';
import { Component, OnInit, AfterViewInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { AddDocComponent } from '../add-doc/add-doc.component';
import { GalleryService } from '../../Services/gallery.service';
import { EditDocComponent } from '../edit-doc/edit-doc.component';
import { ShareComponent } from '../share/share.component';


@Component({
  selector: 'app-doc-gallery',
  templateUrl: './doc-gallery.component.html',
  styleUrls: ['./doc-gallery.component.css'],
  providers: [GalleryService,WsService]
})
export class DocGalleryComponent implements OnInit, AfterViewInit {

  constructor(public dialog: MatDialog, private galleryService: GalleryService ,private wsService:WsService) { }

  myDocuments: Array<DocDATA>
  ngOnInit(): void {
    this.galleryService.onGetAllDocResponseOk.subscribe(data => this.myDocuments = data)
  }

  ngAfterViewInit() {

    this.galleryService.getAllDocs();
  }


  openAddDialog() {
    var dialogRef1 = this.dialog.open(AddDocComponent,{
      minHeight:'700px',
      minWidth:'1000px',
      disableClose:true
    })
      .afterClosed()
      .subscribe((res: any) => {
        if (res.add)
          this.myDocuments.push(res.data)
      })
  }
  openEditDialog(doc: DocDATA) {
    var dialogRef2 = this.dialog.open(EditDocComponent, {
      height: '700px',
      width: '1000px',
      data: doc,
      disableClose:true
    })
  }


  openWs(){
   this.wsService.Start();
  }
  closeWs(){
    this.wsService.Stop()
  }

}
