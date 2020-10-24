using Contracts.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DrawnigContracts.DTO
{
    public class LogInResponseInValidUserNameOrPassword:ResponseInValid
    {
        public LogInResponseInValidUserNameOrPassword(string msg) : base(msg) { }
    }
}
