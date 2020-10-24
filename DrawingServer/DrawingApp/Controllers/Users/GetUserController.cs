using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DTO;
using DrawnigContracts.DTO;
using DrawnigContracts.Interface.UsersInterface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DrawingApp.Controllers.Users
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetUserController : ControllerBase
    {
        IGetUserService _service;
        public GetUserController(IGetUserService service)
        {
            _service = service;
        }
        [HttpGet]
        public Response GetAllUsers()
        {
            return _service.GetAllUsersNames();
        }

        [HttpPost]
        public Response GetUser(GetUserRequest request)
        {
            return _service.GetUser(request);
        }

    }
}
