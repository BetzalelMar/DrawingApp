using DrawnigContracts.DTO.documentsDTO.DocData;
using System;
using System.Collections.Generic;
using System.Text;

namespace DrawnigContracts.DTO.SharedDTO.SharedResponse
{
    public class RemoveSharedResponseOk : ResponseOk<DocInfra>
    {
        public RemoveSharedResponseOk(List<DocInfra> data) : base(data)
        {

        }

    }
}
