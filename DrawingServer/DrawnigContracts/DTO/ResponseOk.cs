using Contracts.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DrawnigContracts.DTO
{
    public class ResponseOk<T>:Response
    {
        public ResponseOk(List<T> data)
        {
            responseData = data;
        }
        public List<T> responseData { get; set; }
    }
}
