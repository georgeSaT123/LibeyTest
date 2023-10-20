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
        public List<UbigeoResponse> GetAllUbigeos(string RegionCode, string ProvinceCode)
        {
            var ubigeos = _context.Ubigeos
                .Where(ubigeo => ubigeo.RegionCode.StartsWith(RegionCode) && ubigeo.ProvinceCode.StartsWith(ProvinceCode))
                .Select(ubigeo => new UbigeoResponse
                {
                    UbigeoCode = ubigeo.UbigeoCode,
                    ProvinceCode = ubigeo.ProvinceCode,
                    RegionCode = ubigeo.RegionCode,
                    UbigeoDescription = ubigeo.UbigeoDescription
                }).ToList();

            return ubigeos;
        }
    }
}