using System.Collections.Generic;

namespace DrawnigContracts.DTO.documentsDTO.DocResponse
{
    public class RemoveDocResponseOk: ResponseOk<string>
    {
        public RemoveDocResponseOk(List<string> docId):base(docId)
        {

        }
    }
}
