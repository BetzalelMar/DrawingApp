using Contracts.DTO;
using DrawnigContracts.DTO.usersDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DrawnigContracts.DTO
{
    public class RegisterResponseOk:ResponseOk<UserData>
    {
        public RegisterResponseOk(List<UserData> request) : base(request) { }
    }
}
