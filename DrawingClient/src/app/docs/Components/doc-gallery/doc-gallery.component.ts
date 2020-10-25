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
  providers: [GalleryService]
})
export class DocGalleryComponent implements OnInit, AfterViewInit {

  constructor(public dialog: MatDialog, private galleryService: GalleryService) { }

  myDocuments: Array<DocDATA>
  sherdDocuments: Array<DocDATA>
  share = false
  ngOnInit(): void {
    console.log('in ngOnInit of Gallery !');
    this.galleryService.onGetAllDocResponseOk.subscribe(data => this.myDocuments = data)
  }

  ngAfterViewInit() {

    this.galleryService.getAllDocs();
  }


  openAddDialog() {
    var dialogRef1 = this.dialog.open(AddDocComponent)
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
      data: doc
    })
  }
  openShareDialog(doc: DocDATA) {
    var dialogRef3 = this.dialog.open(ShareComponent, {
      data: doc
    })
  }



}
