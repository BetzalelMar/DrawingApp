using DrawnigContracts.DTO.documentsDTO.DocData;
using System.Collections.Generic;

namespace DrawnigContracts.DTO.documentsDTO.DocResponse
{
    public class GetAllDocResponseOk: ResponseOk<DocInfra>
    {
        public GetAllDocResponseOk(List<DocInfra> allDocs):base(allDocs)
        {

        }
    }
}
