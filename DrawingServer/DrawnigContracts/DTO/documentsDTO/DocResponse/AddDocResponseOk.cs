

using DrawnigContracts.DTO.documentsDTO.DocData;
using System.Collections.Generic;

namespace DrawnigContracts.DTO.DocsDTO.Response
{
    public class AddDocResponseOk : ResponseOk<DocInfra>
    {
        public AddDocResponseOk(List<DocInfra> docinfra) :base(docinfra)
        {

        }
    }
}
