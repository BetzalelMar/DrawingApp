using DrawnigContracts.DTO.documentsDTO.DocData;
using DrawnigContracts.DTO.FreeDraw;
using DrawnigContracts.DTO.MarkersDTO.markerDataDto;
using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Text;

namespace DrawnigContracts.Interface
{
    public interface IWsAppService
    {
        void Register(string userId,WebSocket ws);
        void sendMarker(string docId,MarkerData marker);
        void sendDoc(string userId,DocInfra doc);
        void sendFreeDraw(string docId,FreeDrawData marker);
    }
}
