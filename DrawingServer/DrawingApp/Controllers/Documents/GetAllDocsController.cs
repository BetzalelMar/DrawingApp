using Contracts.DTO;
using DrawnigContracts.DTO.DocsDTO;
using DrawnigContracts.Interface.DocInterface;
using Microsoft.AspNetCore.Mvc;

namespace DrawingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetAllDocsController : ControllerBase
    {
        IGetAllDocService _service;
        public GetAllDocsController(IGetAllDocService service)
        {
            _service = service;
        }
        [HttpPost]
        public Response GetAllDocs([FromBody] GetAllDocsRequest request)
        {
            return _service.GetAllDocs(request);
        }
    }
}