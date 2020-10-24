using System;
using System.Collections.Generic;
using System.Text;

namespace DrawnigContracts.DTO.MarkersDTO.markerDataDto
{
    public class Point
    {
        public double x { get; set; }
        public double y { get; set; }

        public override string ToString()
        {
            return "{x:" + x + ", y:" + y + "}";
        }

    }
}
