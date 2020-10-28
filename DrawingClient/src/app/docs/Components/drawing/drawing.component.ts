import { FreeDrawData } from './../../../DTO/DATA/free-draw-data';
import { map } from 'rxjs/operators';
import { Observable, Subject } from 'rxjs';
import { DrawingService}from '../../Services/drawing.service'
import { Point } from '../../../DTO/DATA/point';
import { Component, ElementRef, Input, OnInit, ViewChild, AfterViewInit } from '@angular/core';
import { Ellipse } from '../../../DTO/DATA/ellipse';
import { Rectangle } from '../../../DTO/DATA/rectangle';

@Component({
  selector: 'app-drawing',
  templateUrl: './drawing.component.html',
  styleUrls: ['./drawing.component.css']
})
export class DrawingComponent implements OnInit,AfterViewInit {

  @ViewChild('freeDrawCanvas') freeDrawCanvasRef: ElementRef<HTMLCanvasElement>;
  @ViewChild('shapeCanvas') canvasShapeRef: ElementRef<HTMLCanvasElement>;


  @Input() docId: string;
  localScreen:Point
  @Input()height;
  @Input()width;
  constructor(public drawingService: DrawingService) { }
  ngAfterViewInit(): void {
    this.freeDrawCanvasRef.nativeElement.width  = this.freeDrawCanvasRef.nativeElement.offsetWidth;
    this.freeDrawCanvasRef.nativeElement.height= this.freeDrawCanvasRef.nativeElement.offsetHeight;
    this.canvasShapeRef.nativeElement.width  = this.canvasShapeRef.nativeElement.offsetWidth;
    this.canvasShapeRef.nativeElement.height = this.canvasShapeRef.nativeElement.offsetHeight;
    this.localScreen=new Point(this.freeDrawCanvasRef.nativeElement.width,this.freeDrawCanvasRef.nativeElement.height);
  }
  
  ngOnInit(): void {
    this.drawingService.subjectRegister(this.docId)
    this.drawingService.onDrawFree(this.docId).subscribe(freeDrawData => this.freeDraw(freeDrawData))
    this.drawingService.onDrawEllipse(this.docId).subscribe(marker =>{this.drawEllipse(marker);this.clearCanvas(this.freeDrawCanvasRef.nativeElement);})
    this.drawingService.onDrawRectangle(this.docId).subscribe(marker => {this.drawRectangle(marker);this.clearCanvas(this.freeDrawCanvasRef.nativeElement);})
    this.drawingService.onclearCanvas(this.docId).subscribe(res=> this.clearCanvas(this.canvasShapeRef.nativeElement))
  }

  drawEllipse(marker: Ellipse) {
    var center=this.scal(marker.markerLocation.pos,marker.originScreen)
    var radius=this.scal(marker.markerLocation.radius,marker.originScreen)
    var ctx = this.canvasShapeRef.nativeElement.getContext('2d');
    ctx.beginPath()
    ctx.globalAlpha = 0.2;
    ctx.strokeStyle = marker.markerColor.backColor
    ctx.ellipse(center.x,center.y,radius.x,radius.y, 0, 0, 2 * Math.PI);
    ctx.fill()
    ctx.globalAlpha = 1.0;
    ctx.strokeStyle = marker.markerColor.backColor
    ctx.stroke();
  }

  drawRectangle(marker: Rectangle) {
    var startPos=this.scal(marker.markerLocation.pos,marker.originScreen)
    var radius=this.scal(marker.markerLocation.radius,marker.originScreen)
    var ctx = this.canvasShapeRef.nativeElement.getContext('2d');
    ctx.beginPath()
    ctx.globalAlpha = 0.2;
    ctx.fillStyle=marker.markerColor.backColor
    ctx.fillRect(startPos.x, startPos.y,radius.x,radius.y);
    ctx.globalAlpha = 1.0;
    ctx.strokeStyle = marker.markerColor.foreColor
    ctx.rect(startPos.x, startPos.y,radius.x,radius.y);
    ctx.stroke();
  }
  
  freeDraw(freeDrawData:FreeDrawData) {
    var from=this.scal(freeDrawData.from,freeDrawData.originScreen)
    var to=this.scal(freeDrawData.to,freeDrawData.originScreen)

    var ctx = this.freeDrawCanvasRef.nativeElement.getContext('2d');
    ctx.lineCap = 'round';
    ctx.strokeStyle = freeDrawData.color
    ctx.beginPath()
    ctx.moveTo(from.x, from.y);
    ctx.lineTo(to.x, to.y);
    ctx.stroke()
  }

  clearCanvas(canvas:any){
    var ctx = canvas.getContext('2d');
    ctx.beginPath()
    ctx.clearRect(0,0,canvas.width,canvas.height)
    ctx.stroke()
  }

  scal(point:Point,originScreen:Point){
    return new Point(point.x,point.y).calc(originScreen, this.localScreen)
  }
}
