using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibeyTechnicalTestAPI.Controllers.DocumentType
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentTypeController : Controller
    {
        private readonly IDocumentTypeAggregate _aggregate;
        public DocumentTypeController(IDocumentTypeAggregate aggregate)
        {
            _aggregate = aggregate;
        }
        [HttpGet]
        [Route("all")]
        public IActionResult GetAllDocumentTypes()
        {
            var documents = _aggregate.GetAllDocumentTypes();
            return Ok(documents);
        }
    }
}
