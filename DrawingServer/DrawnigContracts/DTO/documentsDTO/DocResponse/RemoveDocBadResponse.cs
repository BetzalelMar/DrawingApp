using System;
using System.Collections.Generic;
using System.Text;

namespace DrawnigContracts.DTO.documentsDTO.DocResponse
{
    public class RemoveDocBadResponse:ResponseInValid
    {
        public RemoveDocBadResponse(string message):base(message)
        {

        }
    }
}
