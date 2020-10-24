using DrawnigContracts.DTO.documentsDTO.DocData;
using System;
using System.Collections.Generic;
using System.Text;

namespace DrawnigContracts.DTO.SharedDTO.SharedResponse
{
    public class GetAllSharedResponseOk:ResponseOk<DocInfra>
    {
        public GetAllSharedResponseOk(List<DocInfra> data):base(data)
        {

        }
    }
}
