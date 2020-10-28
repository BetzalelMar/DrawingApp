import { ResponseB } from 'src/app/DTO/Response/response';
import { Marker } from './../../DTO/DATA/Marker';
import { FreeDrawData } from './../../DTO/DATA/free-draw-data';
import { buffer, filter, map, pairwise, switchMap, take, takeUntil } from 'rxjs/operators';
import { MarkerColor } from './../../DTO/DATA/marker-color';
import { ShapeService } from './shape.service';
import { MarkerService } from './marker.service';
import { fromEvent, Subject } from 'rxjs';
import { DrawingService } from './drawing.service';
import { Injectable } from '@angular/core';
import { Point } from '../../DTO/DATA/point';

import { MarkerData } from 'src/app/DTO/DATA/marker-data';
 
@Injectable()
export class EditDocService {

  constructor(private drawingService: DrawingService, private markerService: MarkerService,private shapeService:ShapeService) {

  }
  
  docId:string;
  mode:string='Rectangle';
  color:MarkerColor=new MarkerColor()
  originScreen:Point;
  
  polySubject: Subject<Point> = new Subject<Point>()

  freeDraw(freeDrawData:FreeDrawData) {
    this.drawingService.DrawingFunc['Free'](this.docId,freeDrawData)
    this.polySubject.next(freeDrawData.from)
    this.polySubject.next(freeDrawData.to)
  }

  drawShape(marker:Marker) {
    this.markerService.addMarker(this.docId,marker)
    this.markerService.onAddMarkerOk.pipe(take(1),map((res:ResponseB)=>res.responseData[0]))
    .subscribe((res:any)=> this.drawingService.DrawingFunc[res.marker.markerType](res.docId,res.marker))    
  }

  clearMarkers(){
    this.markerService.RemoveAllMarkersByDoc(this.docId)
    this.markerService.onRemoveAllMarkersByDocOk.pipe(map((res:ResponseB)=>res.responseData[0]))
    .subscribe(docData=>this.drawingService.clearCanvas(docData.docId))
  }
 
 mouseEvents(canvas:HTMLCanvasElement){
  var mousedown$ = fromEvent(canvas, 'mousedown');
  var mousemove$ = fromEvent(canvas, 'mousemove');
  var mouseup$=fromEvent(canvas, 'mouseup');
  var mouseleave$=fromEvent(canvas, 'mouseleave')
  mousedown$.pipe(
    switchMap(event =>
      mousemove$.pipe(
        takeUntil(mouseup$),
        takeUntil(mouseleave$),
        pairwise()
      )))
  .pipe(map((points: [MouseEvent, MouseEvent]) =>{
    const rect = canvas.getBoundingClientRect(); 
    return {
      from:new Point( points[0].clientX - rect.left,  points[0].clientY - rect.top) ,
      to:new Point( points[1].clientX - rect.left,  points[1].clientY - rect.top),
      color :this.color.foreColor,
      originScreen:this.originScreen
    }}))
    .subscribe((freeDrawData:FreeDrawData) => {
      this.freeDraw(freeDrawData)
    })
    this.polySubject.pipe(
      buffer(mouseup$)
    )
    .pipe(filter(poly=>poly.length>0))
    .pipe(map(shapePoly=>this.shapeService.Resolver[this.mode](shapePoly,this.color,this.originScreen)))
    .subscribe((marker:Marker)=>this.drawShape(marker))

 }

}
