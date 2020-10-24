using Contracts.DTO;
using DrawnigContracts.DTO.MarkersDTO;

namespace DrawnigContracts.Interface.MarkerInterface
{
    public interface IRemoveAllMarkersByDocService
    {
       Response RemoveAllMarkersByDoc(RemoveAllMarkersByDocRequest request);
    }
}
