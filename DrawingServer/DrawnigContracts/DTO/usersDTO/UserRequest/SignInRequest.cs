using System;
using System.Collections.Generic;
using System.Text;

namespace DrawnigContracts.DTO
{
    public class LogInRequest
    {
        public string userId { get; set; }
        public string userPassword { get; set; }
    }
}
