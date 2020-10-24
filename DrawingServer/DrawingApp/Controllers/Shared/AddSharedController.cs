using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DTO;
using DrawnigContracts.DTO.SharedDTO.SharedRequest;
using DrawnigContracts.Interface.SharedInterface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DrawingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddSharedController : ControllerBase
    {
        IAddSharedService _service;
        public AddSharedController(IAddSharedService service)
        {
            _service = service;
        }

        [HttpPost]
        public Response AddShared(AddSharedRequest request)
        {
            return this._service.AddShaerd(request);
        }
    }
}