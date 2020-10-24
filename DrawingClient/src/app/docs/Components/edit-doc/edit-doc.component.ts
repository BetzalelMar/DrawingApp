import { FormControl, Validators } from '@angular/forms';
import { MarkerColor } from './../../../DTO/DATA/marker-color';
import { DrawingService } from './../../Services/drawing.service';
import { EditDocService } from './../../Services/edit-doc.service';
import { DocDATA } from '../../../DTO/DATA/doc-data';
import { DrawingComponent } from '../drawing/drawing.component';
import { Component, OnInit, AfterViewInit, ViewChild, Inject, Input, ElementRef } from '@angular/core';
import { fromEvent } from 'rxjs';
import { switchMap, takeUntil, pairwise, map, buffer } from 'rxjs/operators';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Point } from 'src/app/DTO/DATA/point';
import { MarkerService } from '../../Services/marker.service';
import { DocComponent } from '../doc/doc.component';


@Component({
  selector: 'app-edit-doc',
  templateUrl: './edit-doc.component.html',
  styleUrls: ['./edit-doc.component.css'],
  providers:[MarkerService,EditDocService]
})
export class EditDocComponent implements OnInit, AfterViewInit {
  @ViewChild('Doc',{ static: true }) docComponent: DocComponent;

  doc:DocDATA
  mode:string='Rectangle'
  @ViewChild('fcolor') fcolor:ElementRef
  @ViewChild('bcolor') bcolor:ElementRef
  color:MarkerColor=new MarkerColor();
  originScreen:Point;
  constructor(@Inject(MAT_DIALOG_DATA) public data: any,private editDocService:EditDocService) {
    this.doc = data;
  }

  
  ngAfterViewInit(): void {
    fromEvent(this.fcolor.nativeElement,'change').subscribe((v:any)=>this.color['foreColor']=v.target.value)
    fromEvent(this.bcolor.nativeElement,'change').subscribe((v:any)=>this.color['backColor']=v.target.value)
    var canvasEl=this.docComponent.drawingComponent.freeDrawCanvasRef.nativeElement
    this.originScreen=new Point(canvasEl.width,canvasEl.height)
    var mousedown$ = fromEvent(canvasEl, 'mousedown');
    var mousemove$ = fromEvent(canvasEl, 'mousemove');
    var mouseup$=fromEvent(canvasEl, 'mouseup');

    mousedown$.pipe(
      switchMap(event =>
        mousemove$.pipe(
          takeUntil(mouseup$),
          takeUntil(fromEvent(canvasEl, 'mouseleave')),
          pairwise()
        ))
    ).pipe(map((res: [MouseEvent, MouseEvent]) => {
      const rect = canvasEl.getBoundingClientRect();
      return res.map(point => {
        return {
          x: point.clientX - rect.left,
          y: point.clientY - rect.top
        }
      })
    }))

      .subscribe((res:Array<Point>) => {
        this.editDocService.freeDraw(this.doc.docId,res,this.originScreen)
      })

      this.editDocService.polySubject.pipe(
        buffer(mouseup$)
      )
      .subscribe(res=>this.editDocService.drawShape(this.doc.docId,this.mode,this.color,res,this.originScreen))
  

  }

  ngOnInit(): void {
  }

  onEllipse(){
    this.mode='Ellipse'
  }
 onRec(){
   this.mode='Rectangle'
 }
 clearMarkers(){
   this.editDocService.clearMarkers(this.doc.docId)
 }
}
