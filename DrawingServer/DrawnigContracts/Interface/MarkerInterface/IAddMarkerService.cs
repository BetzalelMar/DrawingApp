using Contracts.DTO;
using DrawnigContracts.DTO.MarkersDTO.markerDataDto;
using DrawnigContracts.DTO.MarkersDTO.MarkersRequest;

namespace DrawnigContracts.Interface.MarkerInterface
{
    public interface IAddMarkerService
    {
        public Response AddMarker(AddMarkerRequest request);
    }
}
