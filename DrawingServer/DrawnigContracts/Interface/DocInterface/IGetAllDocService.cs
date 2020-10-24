using Contracts.DTO;
using DrawnigContracts.DTO.DocsDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DrawnigContracts.Interface.DocInterface
{
    public interface IGetAllDocService
    {
        public Response GetAllDocs(GetAllDocsRequest request);
    }
}
