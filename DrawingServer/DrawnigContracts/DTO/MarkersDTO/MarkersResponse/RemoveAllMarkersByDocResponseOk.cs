using System;
using System.Collections.Generic;
using System.Text;

namespace DrawnigContracts.DTO.MarkersDTO.MarkersResponse
{
    public class RemoveAllMarkersByDocResponseOk:ResponseOk<string>
    {
        public RemoveAllMarkersByDocResponseOk(List<string> msg):base(msg)
        {

        }
    }
}
