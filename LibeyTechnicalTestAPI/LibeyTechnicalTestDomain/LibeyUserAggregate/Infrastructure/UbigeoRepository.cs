using LibeyTechnicalTestDomain.EFCore;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Infrastructure
{
    public class UbigeoRepository : IUbigeoRepository
    {
        private readonly Context _context;
        public UbigeoRepository(Context context)
        {
            _context = context;
        }
        public List<UbigeoResponse> GetAllUbigeos()
        {
            var ubigeo = _context.Ubigeos.Select(ubigeo => new UbigeoResponse
            {
                UbigeoCode = ubigeo.RegionCode,
                ProvinceCode = ubigeo.ProvinceCode,
                RegionCode = ubigeo.RegionCode,
                UbigeoDescription = ubigeo.UbigeoDescription,
            }).ToList();

            return ubigeo;
        }
    }
}