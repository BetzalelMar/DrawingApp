using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DTO;
using DrawnigContracts.DTO.DocsDTO;
using DrawnigContracts.DTO.DocsDTO.Response;
using DrawnigContracts.Interface;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DrawingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddDocController : ControllerBase
    {
        IAddDocService _service;

        public AddDocController(IAddDocService service)
        {
            _service = service;
        }
        [HttpPost]
        public Response AddDoc([FromBody] AddDocRequest request)
        {
            return _service.AddDoc(request);
        }

    }
}