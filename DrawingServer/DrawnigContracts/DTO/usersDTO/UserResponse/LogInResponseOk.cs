using Contracts.DTO;
using DrawnigContracts.DTO.usersDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DrawnigContracts.DTO
{
    public class LogInResponseOk:ResponseOk<UserData>
    {
        public LogInResponseOk(List<UserData> request) : base(request) { }
    }
}
