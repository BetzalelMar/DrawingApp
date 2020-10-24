using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DTO;
using DrawnigContracts.DTO.DocsDTO.DocRequest;
using DrawnigContracts.Interface.DocInterface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DrawingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RemoveDocController : ControllerBase
    {
        IRemoveDocService _removeDocService;
        public RemoveDocController(IRemoveDocService removeDocService)
        {
            _removeDocService = removeDocService;
        }

        [HttpPost]
        public Response RemoveDoc([FromBody]RemoveDocRequest request)
        {
            return _removeDocService.removeDoc(request);
        }
    }
}