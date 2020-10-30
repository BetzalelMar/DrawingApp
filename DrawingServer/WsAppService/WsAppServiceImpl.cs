using Contracts;
using DrawnigContracts.DTO;
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
            var msg = new WsAppDocMessage(doc);
            await _wsService.Send(userId, msg);
        }

        public  void sendFreeDraw(string docId, FreeDrawData freeDraw)
        {
            var msg = new WsAppFreeDrawMessage(freeDraw);
            List<string> list = _docToUsersService.GetUsersByDoc(docId);
            list.Where(user => user != freeDraw.userId).ToList().ForEach(async user => await _wsService.Send(user,msg));
        }

        public  void sendMarker(string docId, MarkerData marker)
        {
            var msg = new WsAppMarkerMessage(marker);

            List<string> list = _docToUsersService.GetUsersByDoc(docId);
            list.Where(user => user != marker.userId).ToList().ForEach(async user => await _wsService.Send(user, msg));
        }

        public void sendClear(string docId, string userId)
        {
            var msg = new WsAppClearMessage(docId);
            List<string> list = _docToUsersService.GetUsersByDoc(docId);
            list.Where(user => user != userId).ToList().ForEach(async user => await _wsService.Send(user, msg));
        }

    }
}
