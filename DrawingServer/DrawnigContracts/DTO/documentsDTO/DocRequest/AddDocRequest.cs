using System;
using System.Collections.Generic;
using System.Text;

namespace DrawnigContracts.DTO.DocsDTO
{
    public class AddDocRequest
    {
        public string ownerId { get; set; }
        public string docName { get; set; }
        public string docUrl { get; set; }
    }
}
