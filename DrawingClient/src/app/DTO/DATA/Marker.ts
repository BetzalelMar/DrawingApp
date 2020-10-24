import { MarkerColor } from './marker-color';
import { MarkerLocation } from './marker-location';
import { Point } from './point';
export class Marker {
    markerColor: MarkerColor
    markerType: string
    markerLocation: MarkerLocation
    markerId: string = null;
    originScreen:Point
}
