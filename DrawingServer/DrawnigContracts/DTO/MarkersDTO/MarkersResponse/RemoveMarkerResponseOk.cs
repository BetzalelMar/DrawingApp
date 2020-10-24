using System;
using System.Collections.Generic;
using System.Text;

namespace DrawnigContracts.DTO.MarkersDTO.MarkersResponse
{
    public  class RemoveMarkerResponseOk:ResponseOk<string>
    {
        public RemoveMarkerResponseOk(List<string> message):base(message)
        {

        }
    }
}
