using DrawnigContracts.DTO.documentsDTO.DocData;
using System.Collections.Generic;

namespace DrawnigContracts.DTO.documentsDTO.DocResponse
{
    public class GetDocResponseOk:ResponseOk<DocInfra>
    {
        public GetDocResponseOk(List<DocInfra >docInfra):base(docInfra)
        {

        }
    }
}
