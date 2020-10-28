import { FreeDrawData } from './../../DTO/DATA/free-draw-data';
import { Point } from './../../DTO/DATA/point';
import { Injectable } from '@angular/core';
import { Subject, Observable, Subscriber } from 'rxjs';
import { Marker } from 'src/app/DTO/DATA/Marker';

@Injectable({
  providedIn: 'root'
})
export class DrawingService {

  constructor() {
  
   }
  DrawingSubject: { [DrawingType: string]: { [id: string]: Subject<any> } } = {
    FreeDraw: {},
    EllipseDraw: {},
    RectangleDraw: {},
    ImageDraw:{},
    FinishedDrawingImage:{},
    ClearCanvas:{}
  }

    DrawingFunc:{[drawingType:string]:any}={
    Rectangle:this.drawRec.bind(this),
    Ellipse:this.drawEllipse.bind(this),
    Free:this.freeDraw.bind(this),
    clear:this.clearCanvas.bind(this)
  }
  subjectRegister(subjectId: string) {
    if (this.DrawingSubject['FreeDraw'].hasOwnProperty(subjectId)) return;
    this.DrawingSubject.FreeDraw[subjectId] = new Subject<any>();
    this.DrawingSubject.EllipseDraw[subjectId]  = new Subject<any>();
    this.DrawingSubject.RectangleDraw[subjectId]  = new Subject<any>();
    this.DrawingSubject.ClearCanvas[subjectId]  = new Subject<any>();

  }
  clearCanvas(subjectId: string,){
    this.onclearCanvas(subjectId).next();
  }
  freeDraw(subjectId: string,freeDrawData:FreeDrawData) {
    this.onDrawFree(subjectId).next(freeDrawData);
  }

  drawEllipse(subjectId:string,Marker:Marker){
    this.onDrawEllipse(subjectId).next(Marker);
  }
  drawRec(subjectId:string,Marker:Marker){
    this.onDrawRectangle(subjectId).next(Marker);
  }
  

  onDrawEllipse(subjectId: string) { return this.DrawingSubject['EllipseDraw'][subjectId] };
  onDrawRectangle(subjectId: string) { return this.DrawingSubject['RectangleDraw'][subjectId] };
  onDrawFree(subjectId: string) { return this.DrawingSubject['FreeDraw'][subjectId] };
  onclearCanvas(subjectId: string) { return this.DrawingSubject['ClearCanvas'][subjectId] };

}
