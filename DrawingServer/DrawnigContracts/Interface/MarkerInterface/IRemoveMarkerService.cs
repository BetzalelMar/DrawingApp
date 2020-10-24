using Contracts.DTO;
using DrawnigContracts.DTO.MarkersDTO.MarkersRequest;

namespace DrawnigContracts.Interface.MarkerInterface
{
    public interface IRemoveMarkerService
    {
        public Response RemoveMarker(RemoveMarkerRequest request);
    }
}
