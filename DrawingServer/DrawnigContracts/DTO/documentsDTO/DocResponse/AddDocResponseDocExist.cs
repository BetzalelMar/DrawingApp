using System;
using System.Collections.Generic;
using System.Text;

namespace DrawnigContracts.DTO.DocsDTO.Response
{
    public class AddDocResponseDocExist:ResponseInValid
    {
        public AddDocResponseDocExist(string msg) : base(msg) { }
    }
}
