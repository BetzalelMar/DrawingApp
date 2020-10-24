using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DTO;
using DrawnigContracts.DTO.MarkersDTO;
using DrawnigContracts.Interface.MarkerInterface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DrawingApp.Controllers.Markers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RemoveAllMarkersByDocController : ControllerBase
    {
        IRemoveAllMarkersByDocService _removeMarkercService;
        public RemoveAllMarkersByDocController(IRemoveAllMarkersByDocService removeMarkercService)
        {
            _removeMarkercService = removeMarkercService;
        }
        [HttpPost]
        public Response RemoveAllMarkersByDoc([FromBody] RemoveAllMarkersByDocRequest request)
        {
            return _removeMarkercService.RemoveAllMarkersByDoc(request);
        }

    }
}
