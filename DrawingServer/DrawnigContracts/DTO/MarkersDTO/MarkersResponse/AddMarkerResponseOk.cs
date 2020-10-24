using DrawnigContracts.DTO.MarkersDTO.markerDataDto;
using System;
using System.Collections.Generic;
using System.Text;

namespace DrawnigContracts.DTO.MarkersDTO.MarkersResponse
{
    public class AddMarkerResponseOk :ResponseOk<MarkerData>
    {
        public AddMarkerResponseOk(List<MarkerData> data):base(data)
        {

        }
    }
}
