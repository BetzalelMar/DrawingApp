using Contracts.DTO;
using DrawnigContracts.DTO.DocsDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DrawnigContracts.Interface
{
    public interface IAddDocService
    {
        public Response AddDoc(AddDocRequest request);
    }
}
