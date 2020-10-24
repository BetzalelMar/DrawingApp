using Contracts;
using Contracts.DTO;
using DrawnigContracts.DTO;
using DrawnigContracts.DTO.MarkersDTO;
using DrawnigContracts.DTO.MarkersDTO.MarkersRequest;
using DrawnigContracts.DTO.MarkersDTO.MarkersResponse;
using DrawnigContracts.Interface;
using DrawnigContracts.Interface.MarkerInterface;
using System;
using System.Data;
using System.Diagnostics;
using System.Linq;

namespace MarkerService
{
    [Register(Policy.Transient,typeof(IGetAllMarkersByDocService))]
    public class GetAllMarkersByDocService : IGetAllMarkersByDocService
    {
        IMarkersDal _dal;
        IMarkerConvertor _convertor;
        public GetAllMarkersByDocService(IMarkersDal dal, IMarkerConvertor convertor)
        {
            _dal = dal;
            _convertor = convertor;
        }
        public Response GetAllMarkersByDoc(GetAllMarkersByDocRequest request)
        {
            Response retval;
            // doc exist?
            try
            {
                var dbResponse = _dal.GetMarkersByDoc(request.docId).Tables[0];

                var data = _convertor.convertTableToList(dbResponse);

                retval = new GetAllMarkersByDocResponseOk(data);
            }
            catch (Exception)
            {

                retval = new AppResponseError();
            }
            return retval;

        }
    }
}
