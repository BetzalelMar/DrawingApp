using Contracts.DTO;
using DrawnigContracts.DTO.DocsDTO;
using DrawnigContracts.DTO.MarkersDTO.MarkersRequest;

namespace DrawnigContracts.Interface.MarkerInterface
{
    public interface IGetAllMarkersByDocService
    {
        public Response GetAllMarkersByDoc(GetAllMarkersByDocRequest request);
    }
}
