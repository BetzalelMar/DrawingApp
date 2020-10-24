using Contracts.DTO;
using DrawnigContracts.DTO;
using DrawnigContracts.Interface;
using Microsoft.AspNetCore.Mvc;

namespace DrawingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        IRegisterService _service;
        public RegisterController(IRegisterService service)
        {
            _service = service;
        }
        
        [HttpPost]
        public Response Register([FromBody] RegisterRequest request)
        {
            return _service.Register(request);
        }
    }
}