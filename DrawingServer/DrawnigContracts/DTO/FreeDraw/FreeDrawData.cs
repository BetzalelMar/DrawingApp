using DrawnigContracts.DTO.MarkersDTO.markerDataDto;
using System;
using System.Collections.Generic;
using System.Text;

namespace DrawnigContracts.DTO.FreeDraw
{
    public class FreeDrawData
    {
        public string userId { get; set; }
        public Point from { get; set; }
        public Point to { get; set; }
        public string color { get; set; }
        public Point originScreen { get; set; }
    }
}
