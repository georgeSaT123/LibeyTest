using LibeyTechnicalTestDomain.EFCore;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Infrastructure
{
    public class RegionRepository : IRegionRepository
    {
        private readonly Context _context;
        public RegionRepository(Context context)
        {
            _context = context;
        }
        public List<RegionResponse> GetAllRegions()
        {
            var region = _context.Regions.Select(region => new RegionResponse
            {
                RegionCode = region.RegionCode,
                RegionDescription = region.RegionDescription,
            }).ToList();

            return region;
        }
    }
}