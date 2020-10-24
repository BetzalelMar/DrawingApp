import { Ellipse } from './../../DTO/DATA/ellipse';
import { Point } from './../../DTO/DATA/point';
import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { Rectangle } from '../../DTO/DATA/rectangle';
import { MarkerColor } from '../../DTO/DATA/marker-color';

@Injectable({
  providedIn: 'root'
})
export class ShapeService {

  constructor() { }

Resolver:{[shapeType:string]:any}={
  Rectangle:this.CreateRec,
  Ellipse:this.createEllipse
}

  CreateRec(shapePoly:Array<Point>,color:MarkerColor,originScreen:Point):Rectangle{
    //if (shapePoly.length==0)return
    var Rec=new Rectangle()
    Rec.markerType='Rectangle'
    Rec.markerColor=color;
    Rec.originScreen=originScreen
    var topy = shapePoly.reduce((acc, pt) => acc = (acc.y < pt.y) ? acc : pt ).y;
    var btny = shapePoly.reduce((acc, pt) => acc = (acc.y > pt.y) ? acc : pt).y;
    var lftx = shapePoly.reduce((acc, pt) => acc = (acc.x < pt.x) ? acc : pt).x;
    var rightx = shapePoly.reduce((acc, pt) => acc = (acc.x > pt.x) ? acc : pt).x;
    var startPos=new Point(lftx,topy);
    var radius=new Point(rightx-startPos.x,btny-startPos.y);
    Rec['markerLocation']={pos:startPos,radius:radius}
    return Rec;
  }

  createEllipse(shapePoly:Array<Point>,color:MarkerColor,originScreen:Point):Ellipse{ 
    var retval=new Ellipse();
    retval.markerType='Ellipse';
    retval.markerColor=color;
    retval.originScreen=originScreen
    var center = new Point(0, 0)
    center=center.add(shapePoly[0])
    center = shapePoly.reduce((acc:Point, pt:Point)=>new Point(acc.x,acc.y).add(pt))
    center = center.div(shapePoly.length)
    var radius = new Point(0, 0)
    radius = shapePoly.reduce((acc:Point, pt:Point) =>new Point(acc.x,acc.y).add(new Point(Math.abs(pt.x - center.x), Math.abs(pt.y- center.y))))
    radius = radius.div(shapePoly.length)
    retval['markerLocation']={pos:center,radius:radius};
    return retval;
  }


}
