using DrawnigContracts.DTO.MarkersDTO.markerDataDto;
using System.Collections.Generic;

namespace DrawnigContracts.DTO.MarkersDTO.MarkersResponse
{
    public  class GetAllMarkersByDocResponseOk:ResponseOk<MarkerData>
    {
        public GetAllMarkersByDocResponseOk(List<MarkerData> listMarkers):base(listMarkers)
        {

        }
    }
}
