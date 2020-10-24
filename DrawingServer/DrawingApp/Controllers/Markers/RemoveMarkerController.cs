using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DTO;
using DrawnigContracts.DTO.MarkersDTO.MarkersRequest;
using DrawnigContracts.Interface.MarkerInterface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DrawingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RemoveMarkerController : ControllerBase
    {
        IRemoveMarkerService _removeMarkercService;
        public RemoveMarkerController(IRemoveMarkerService removeMarkercService)
        {
            _removeMarkercService = removeMarkercService;
        }
        [HttpPost]
        public Response RemoveMarker([FromBody] RemoveMarkerRequest request)
        {
            return _removeMarkercService.RemoveMarker(request);
        }

    }
}