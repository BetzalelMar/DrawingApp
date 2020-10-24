using Contracts.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DrawnigContracts.DTO
{
    public class ResponseInValid:Response
    {
        public ResponseInValid(string msg)
        {
            responseMessage = msg;
        }
        public string responseMessage { get; set; }
    }
}
