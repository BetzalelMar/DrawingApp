using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DTO;
using DrawnigContracts.DTO.SharedDTO.SharedRequest;
using DrawnigContracts.Interface.SharedInterface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DrawingApp.Controllers.Shared
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetAllSharedController : ControllerBase
    {
        IGetAllSharedService _service;
        public GetAllSharedController(IGetAllSharedService service)
        {
            _service = service;
        }

        [HttpPost]
        public Response AddShared(GetAllSharedRequest request)
        {
            return this._service.GetAllSeared(request);
        }
    }
}