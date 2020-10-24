using DrawnigContracts.DTO.documentsDTO.DocData;
using System;
using System.Collections.Generic;
using System.Text;

namespace DrawnigContracts.DTO.SharedDTO.SharedResponse
{
    public class AddSharedResponseOk : ResponseOk<DocInfra>
    {
        public AddSharedResponseOk(List<DocInfra> response):base(response)
        {

        }
    }
}
