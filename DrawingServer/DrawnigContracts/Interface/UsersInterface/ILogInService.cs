using Contracts.DTO;
using DrawnigContracts.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DrawnigContracts.Interface
{
    public interface ILogInService
    {
        public Response LogIn(LogInRequest request);
    }
}
