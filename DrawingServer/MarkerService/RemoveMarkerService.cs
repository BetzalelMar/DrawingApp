using Contracts;
using Contracts.DTO;
using DrawnigContracts.DTO;
using DrawnigContracts.DTO.MarkersDTO.MarkersRequest;
using DrawnigContracts.DTO.MarkersDTO.MarkersResponse;
using DrawnigContracts.Interface;
using DrawnigContracts.Interface.MarkerInterface;
using System;
using System.Collections.Generic;

namespace MarkerService
{
    [Register(Policy.Transient, typeof(IRemoveMarkerService))]
    public class RemoveMarkerService : IRemoveMarkerService
    {
        IMarkersDal _dal;
        public RemoveMarkerService(IMarkersDal dal)
        {
            _dal = dal;
        }

        public Response RemoveMarker(RemoveMarkerRequest request)
        {
            Response retval;
            //user exist?
            try
            {
                var tb = _dal.RemoveMarker(request.markerId).Tables[0];
                if (tb.Rows.Count != 0)
                    retval = new RemoveMarkerBadResponse("The system failed to remove the marker");
                else
                {
                    var list = new List<string>();
                    list.Add(request.markerId + " Successfully deleted");
                    retval = new RemoveMarkerResponseOk(list);
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
