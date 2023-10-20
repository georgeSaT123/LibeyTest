using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibeyTechnicalTestAPI.Controllers.Region
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController : Controller
    {
        private readonly IRegionAggregate _aggregate;
        public RegionController(IRegionAggregate aggregate)
        {
            _aggregate = aggregate;
        }
        [HttpGet]
        [Route("all")]
        public IActionResult GetAllRegions()
        {
            var regions = _aggregate.GetAllRegions();
            return Ok(regions);
        }
    }
}
