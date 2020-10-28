using Contracts;
using DrawnigContracts.DTO.documentsDTO.DocData;
using DrawnigContracts.DTO.FreeDraw;
using DrawnigContracts.DTO.MarkersDTO.markerDataDto;
using DrawnigContracts.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using WsContracts;

namespace WsAppService
{
    [Register(Policy.Singleton, typeof(IWsAppService))]

    public class WsAppServiceImpl : IWsAppService
    {
        IWsService _wsService;
        IMapDocToUsersService _docToUsersService;
        public WsAppServiceImpl(IWsService ws,IMapDocToUsersService docToUsersService)
        {
            _wsService = ws;
            _docToUsersService = docToUsersService;
        }
        public async void Register(string userId,WebSocket ws)
        {
            await _wsService.Add(userId, ws);
        }

        public async void sendDoc(string userId, DocInfra doc)
        {
            WsMessage<DocInfra> msg = new WsMessage<DocInfra>(doc,"AddDoc");
            await _wsService.Send(userId, msg);
        }

        public  void sendFreeDraw(string docId, FreeDrawData freeDraw)
        {
            List<string> list = _docToUsersService.GetUsersByDoc(docId);
            list.Where(user => user != freeDraw.userId).ToList().ForEach(async user => await _wsService.Send(user, new WsMessage<FreeDrawData>(freeDraw, "FreeDraw")));
        }

        public  void sendMarker(string docId, MarkerData marker)
        {
            List<string> list = _docToUsersService.GetUsersByDoc(docId);
            list.Where(user => user != marker.userId).ToList().ForEach(async user => await _wsService.Send(user, new WsMessage<MarkerData>(marker, "MarkerDraw")));
        }
    }
}
