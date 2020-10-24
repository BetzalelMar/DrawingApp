using System;
using System.Collections.Generic;
using System.Text;

namespace DrawnigContracts.DTO.MarkersDTO.MarkersResponse
{
    public class RemoveMarkerBadResponse:ResponseInValid
    {
        public RemoveMarkerBadResponse(string message):base(message)
        {

        }
    }
}
