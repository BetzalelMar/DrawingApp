import { switchMap, take } from 'rxjs/operators';
import { EditDocComponent } from './../../../docs/Components/edit-doc/edit-doc.component';
import { MatDialog } from '@angular/material/dialog';
import { MarkerService } from './../../Services/marker.service';
import { DrawingService } from './../../Services/drawing.service';
import { DocDATA } from './../../../DTO/DATA/doc-data';
import { Component, Input, OnInit, ViewChild, AfterViewInit } from '@angular/core';
import { MarkerData } from 'src/app/DTO/DATA/marker-data';
import { DrawingComponent } from '../drawing/drawing.component';

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
    this.drawingService.subjectRegister(this.doc.docId)
    
  }

  ngAfterViewInit() {
    this.markerService.getAllMarkersByDocId(this.doc.docId)
    this.markerService.onGetAllMarkersOk
    .pipe(take(1))
    .subscribe((arrMarkers:Array<MarkerData>)=>{
      
      arrMarkers.forEach(markerData=>
      this.drawingService.DrawingFunc[markerData.marker.markerType](markerData.docId,markerData.marker))
    })


  }


}
