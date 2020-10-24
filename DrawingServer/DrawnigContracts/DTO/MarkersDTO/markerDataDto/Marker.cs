using System;
using System.Collections.Generic;
using System.Text;

namespace DrawnigContracts.DTO.MarkersDTO.markerDataDto
{
    public class Marker
    {
        public MarkerColor markerColor { get; set; }
        public string markerId { get; set; }
        public MarkerLocation markerLocation { get; set; }
        public string markerType { get; set; }
        public Point originScreen { get; set; }
    }
}
