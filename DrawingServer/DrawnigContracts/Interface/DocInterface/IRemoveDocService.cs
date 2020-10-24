using Contracts.DTO;
using DrawnigContracts.DTO.DocsDTO.DocRequest;
using System;
using System.Collections.Generic;
using System.Text;

namespace DrawnigContracts.Interface.DocInterface
{
    public interface IRemoveDocService
    {
        public Response removeDoc(RemoveDocRequest request);
    }
}
