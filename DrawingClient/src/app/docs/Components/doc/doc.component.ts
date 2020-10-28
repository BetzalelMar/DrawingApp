import { ResponseB } from 'src/app/DTO/Response/response';
import { map, take } from 'rxjs/operators';
import { MatDialog } from '@angular/material/dialog';
import { MarkerService } from './../../Services/marker.service';
import { DrawingService } from './../../Services/drawing.service';
import { DocDATA } from './../../../DTO/DATA/doc-data';
import { Component, Input, OnInit, ViewChild, AfterViewInit } from '@angular/core';
import { MarkerData } from 'src/app/DTO/DATA/marker-data';
import { DrawingComponent } from '../drawing/drawing.component';
import { ShareComponent } from '../share/share.component';

@Component({
  selector: 'app-doc',
  templateUrl: './doc.component.html',
  styleUrls: ['./doc.component.css'],
  providers:[MarkerService]
})
export class DocComponent implements OnInit, AfterViewInit {

  constructor(private drawingService: DrawingService,private markerService:MarkerService ,private dialog:MatDialog) { }
  @Input() doc: DocDATA;
  @ViewChild('Drawing',{static:true}) drawingComponent:DrawingComponent;
  markerData:Array<MarkerData>

  ngOnInit(): void {
    this.markerService.onGetAllMarkersOk.pipe(take(1),map((res:ResponseB)=>res.responseData))
    .subscribe((arrMarkers:Array<MarkerData>)=>{
      arrMarkers.forEach(markerData=>
      this.drawingService.DrawingFunc[markerData.marker.markerType](markerData.docId,markerData.marker))
    })

    this.markerService.onGetAllMarkersBad.pipe(take(1))
    .subscribe((res:ResponseB)=>console.log(res.responseMessage))
  }

  ngAfterViewInit() {
    this.markerService.getAllMarkersByDocId(this.doc.docId)
  }

  openShareDialog() {
  }



}
