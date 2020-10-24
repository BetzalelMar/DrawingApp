using Contracts.DTO;
using DrawnigContracts.DTO.SharedDTO.SharedRequest;

namespace DrawnigContracts.Interface.SharedInterface
{
    public interface IAddSharedService
    {
        public Response AddShaerd(AddSharedRequest request);
    }
}
