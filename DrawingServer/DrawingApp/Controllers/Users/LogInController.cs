using Contracts.DTO;
using DrawnigContracts.DTO;
using DrawnigContracts.Interface;
using Microsoft.AspNetCore.Mvc;

namespace DrawingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogInController : ControllerBase
    {
        ILogInService _service;
        public LogInController(ILogInService service)
        {
            _service = service;
        }

        [HttpPost]
        public Response LogIn([FromBody] LogInRequest request)
        {
            return _service.LogIn(request);
        }
    }

}