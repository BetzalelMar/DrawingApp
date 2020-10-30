using DrawnigContracts.DTO.documentsDTO.DocData;
using DrawnigContracts.DTO.FreeDraw;
using DrawnigContracts.DTO.MarkersDTO.markerDataDto;
using System;
using System.Collections.Generic;
using System.Text;
using WsContracts;

namespace DrawnigContracts.DTO
{
    public class WsAppDocMessage:WsMessage
    {
        public WsAppDocMessage(DocInfra data):base(data)
        {
        }
    }
    public class WsAppMarkerMessage : WsMessage
    {
        public WsAppMarkerMessage(MarkerData data) : base(data)
        {
        }
    }
    public class WsAppFreeDrawMessage : WsMessage
    {
        public WsAppFreeDrawMessage(FreeDrawData data) : base(data)
        {
        }
    }
    public class WsAppClearMessage : WsMessage
    {
        public WsAppClearMessage(string docId) : base(docId)
        {
        }
    }



}
