using System;
using System.Collections.Generic;
using System.Text;

namespace DrawnigContracts.DTO.MarkersDTO.markerDataDto
{
    public class MarkerLocation
    {
        public Point pos { get; set; }
        public Point radius { get; set; }
        public override string ToString()
        {
            return "{ pos:" + this.pos.ToString() + ",radius :" + this.radius.ToString() + "}";
        }

    }
}
