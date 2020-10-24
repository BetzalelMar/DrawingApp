import { take } from 'rxjs/operators';
import { MarkerColor } from './../../DTO/DATA/marker-color';
import { ShapeService } from './../../services/logic/Shape.service';
import { MarkerService } from './marker.service';
import { Subject } from 'rxjs';
import { DrawingService } from './drawing.service';
import { Injectable } from '@angular/core';
import { Point } from '../../DTO/DATA/point';

import { MarkerData } from 'src/app/DTO/DATA/marker-data';

@Injectable()
export class EditDocService {

  constructor(private drawingService: DrawingService, private markerService: MarkerService,private shapeService:ShapeService) {
    this.markerService.onRemoveAllMarkersByDocOk.subscribe(docId=>this.drawingService.clearCanvas(docId))

  }

  polySubject: Subject<Point> = new Subject<Point>()

  freeDraw(docId: string, points: Array<Point>,originScreen:Point) {
    points.push(originScreen)
    this.drawingService.DrawingFunc['Free'](docId,points)
    this.polySubject.next(points[0])
    this.polySubject.next(points[1])
  }

  drawShape(docId: string, shapeM: string,color:MarkerColor, shapePoly: Array<Point>,originScreen:Point) {
    
    var Marker =this.shapeService.Resolver[shapeM](shapePoly,color,originScreen)
    this.markerService.addMarker(docId,Marker)
    this.markerService.onAddMarkerOk.pipe(take(1))
    .subscribe((res:any)=> this.drawingService.DrawingFunc[res.marker.markerType](res.docId,res.marker))    
  }

  clearMarkers(docId:string){
    this.markerService.RemoveAllMarkersByDoc(docId)
  }
}
