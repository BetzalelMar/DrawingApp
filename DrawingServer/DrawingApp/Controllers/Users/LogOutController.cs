using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DTO;
using DrawnigContracts.DTO.usersDTO.UserRequest;
using DrawnigContracts.Interface.UsersInterface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DrawingApp.Controllers.Users
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogOutController : ControllerBase
    {
        ILogOutService _service;
        public LogOutController(ILogOutService service)
        {
            _service = service;
        }

        [HttpPost]
        public Response LogIn([FromBody] LogOutRequest request)
        {
            return _service.LogOut(request);
        }
    }

}

