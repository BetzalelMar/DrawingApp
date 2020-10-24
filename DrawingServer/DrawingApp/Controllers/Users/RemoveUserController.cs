using Contracts.DTO;
using DrawnigContracts.DTO.usersDTO;
using DrawnigContracts.Interface.UsersInterface;
using Microsoft.AspNetCore.Mvc;

namespace DrawingApp.Controllers.Users
{
    [Route("api/[controller]")]
    [ApiController]
    public class RemoveUserController : ControllerBase
    {
        IRemoveUserService _service;
        public RemoveUserController(IRemoveUserService service)
        {
            _service = service;
        }

        [HttpPost]
        public Response RemoveUser(RemoveUserRequest request)
        {
            return _service.RemoveUser(request);
        }
    }
}
