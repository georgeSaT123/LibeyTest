using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibeyTechnicalTestAPI.Controllers.Ubigeo
{
    [Route("api/[controller]")]
    [ApiController]
    public class UbigeoController : Controller
    {
        private readonly IUbigeoAggregate _aggregate;
        public UbigeoController(IUbigeoAggregate aggregate)
        {
            _aggregate = aggregate;
        }
        [HttpGet]
        [Route("all")]
        public IActionResult GetAllUbigeos()
        {
            var ubigeos = _aggregate.GetAllUbigeos();
            return Ok(ubigeos);
        }
    }
}