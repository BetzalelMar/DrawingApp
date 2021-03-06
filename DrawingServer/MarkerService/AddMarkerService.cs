﻿using Contracts;
using Contracts.DTO;
using DrawnigContracts.DTO;
using DrawnigContracts.DTO.MarkersDTO.markerDataDto;
using DrawnigContracts.DTO.MarkersDTO.MarkersRequest;
using DrawnigContracts.DTO.MarkersDTO.MarkersResponse;
using DrawnigContracts.Interface;
using DrawnigContracts.Interface.MarkerInterface;
using System;

namespace MarkerService
{
    [Register(Policy.Transient,typeof(IAddMarkerService))]
    public class AddMarkerService : IAddMarkerService
    {
        IMarkersDal _dal;
        IGenerateIdService _generateIDservice;
        IMarkerConvertor _convertor;
        IWsAppService _wsAppService;
        public AddMarkerService(IMarkersDal dal,IWsAppService wsService, IGenerateIdService generateIDservice, IMarkerConvertor convertor)
        {
            _dal = dal;
            _generateIDservice = generateIDservice;
            _convertor = convertor;
            _wsAppService = wsService;
        }

        public Response AddMarker(AddMarkerRequest request)
        {
            Response retval;
            //user exist?
            //doc exist?
            var markerId = _generateIDservice.GenerateId();
            try
            {
                var dbResponse = _dal.CraeteNarker(markerId, request).Tables[0];
                if (dbResponse.Rows.Count == 0)
                {
                    retval = new AddMarkerBadResponse("The system failed to insert the marker");
                }
                else
                {
                    var data = _convertor.convertTableToList(dbResponse);
                    
                    retval = new AddMarkerResponseOk(data);
                    this._wsAppService.sendMarker(data[0].docId, data[0]);
                }
            }
            catch (Exception)
            {

                retval = new AppResponseError();
            }
            return retval;
        }
    }
}
