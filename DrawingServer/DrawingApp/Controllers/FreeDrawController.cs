using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DTO;
using DrawnigContracts.DTO.FreeDraw;
using DrawnigContracts.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DrawingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FreeDrawController : ControllerBase
    {
        IWsAppService _service;
        public FreeDrawController(IWsAppService service)
        {
            _service = service;
        }

        [HttpPost]
        public Response SendFreeDraw(FreeDrawRequest request)
        {
            var retval = new FreeDrawResponseOk();
            this._service.sendFreeDraw(request.freeDrawData.docId,request.freeDrawData);
            return retval;
        }

    }
}
