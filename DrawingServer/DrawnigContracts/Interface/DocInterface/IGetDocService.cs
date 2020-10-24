using Contracts.DTO;
using DrawnigContracts.DTO.DocsDTO;

namespace DrawnigContracts.Interface.DocInterface
{
    public interface IGetDocService
    {
        public Response GetDoc(GetDocRequest reguest);
    }
}
