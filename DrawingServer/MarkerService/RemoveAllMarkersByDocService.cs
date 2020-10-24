using Contracts;
using Contracts.DTO;
using DrawnigContracts.DTO;
using DrawnigContracts.DTO.MarkersDTO;
using DrawnigContracts.DTO.MarkersDTO.MarkersResponse;
using DrawnigContracts.Interface;
using DrawnigContracts.Interface.MarkerInterface;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarkerService
{
    [Register(Policy.Transient, typeof(IRemoveAllMarkersByDocService))]
    class RemoveAllMarkersByDocService : IRemoveAllMarkersByDocService
    {
        IMarkersDal _dal;
        public RemoveAllMarkersByDocService(IMarkersDal dal)
        {
            _dal = dal;
        }

        public Response RemoveAllMarkersByDoc(RemoveAllMarkersByDocRequest request)
        {
            Response retval;
            try
            {
                var tb = _dal.RemoveAllMarkersByDoc(request.docId).Tables[0];
                if (tb.Rows.Count != 0)
                    retval = new RemoveAllMarkersByDocBadResponse("The system failed to remove the marker");
                else
                {
                    var list = new List<string>();
                    list.Add(request.docId);
                    retval = new RemoveAllMarkersByDocResponseOk(list);
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
