using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DTO;
using DrawnigContracts.DTO.MarkersDTO.markerDataDto;
using DrawnigContracts.DTO.MarkersDTO.MarkersRequest;
using DrawnigContracts.Interface;
using DrawnigContracts.Interface.MarkerInterface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DrawingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddMarkerController : ControllerBase
    {
        IAddMarkerService _addMarkerService;
        public AddMarkerController(IAddMarkerService addMakerService)
        {
            _addMarkerService = addMakerService;
        }
        
        [HttpPost]
        public Response AddMarker([FromBody] AddMarkerRequest request)
        {
            return _addMarkerService.AddMarker(request);
        }
    }
}