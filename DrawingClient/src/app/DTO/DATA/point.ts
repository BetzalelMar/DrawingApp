export class Point {
    constructor(public x: number, public y: number) { }
   
    public add(pt: Point): Point {
        return new Point(this.x + pt.x, this.y + pt.y)
      }
      public div(denom: number) {
        return new Point(+(this.x / denom).toFixed(2),+(this.y / denom).toFixed(2))
      }
      public distanceFrom(pt: Point) {
        return Math.sqrt(Math.pow(pt.x - this.x, 2) + Math.pow(pt.y - this.y, 2))
      }
     public  calc(originScreen:Point,localScreen:Point):Point{
        return new Point(this.x*(localScreen.x/originScreen.x),this.y*(localScreen.y/originScreen.y))
      }
    
}
