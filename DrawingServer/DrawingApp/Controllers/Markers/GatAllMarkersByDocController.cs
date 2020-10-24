using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DTO;
using DrawnigContracts.DTO.DocsDTO;
using DrawnigContracts.DTO.MarkersDTO.MarkersRequest;
using DrawnigContracts.Interface.MarkerInterface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DrawingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GatAllMarkersByDocController : ControllerBase
    {
        IGetAllMarkersByDocService _getMarkerByDocService;
        public GatAllMarkersByDocController(IGetAllMarkersByDocService getMarkerByDocService)
        {
            _getMarkerByDocService = getMarkerByDocService;
        }
        [HttpPost]
        public Response GetAllMarkersByDoc([FromBody] GetAllMarkersByDocRequest request)
        {
            return _getMarkerByDocService.GetAllMarkersByDoc(request);
        }

    }
}