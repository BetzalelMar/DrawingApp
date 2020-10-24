using System;
using System.Collections.Generic;
using System.Text;

namespace DrawnigContracts.DTO.usersDTO.UserResponse
{
    public class RegisterResponsePasswordNotMatch:ResponseInValid
    {
        public RegisterResponsePasswordNotMatch(string msg):base(msg)
        {

        }
    }
}
