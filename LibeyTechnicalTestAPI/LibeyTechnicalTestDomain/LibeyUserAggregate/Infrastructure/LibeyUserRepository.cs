using LibeyTechnicalTestDomain.EFCore;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Domain;
using Microsoft.EntityFrameworkCore;

namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Infrastructure
{
    public class LibeyUserRepository : ILibeyUserRepository
    {
        private readonly Context _context;
        public LibeyUserRepository(Context context)
        {
            _context = context;
        }
        public void Create(LibeyUser libeyUser)
        {
            _context.LibeyUsers.Add(libeyUser);
            _context.SaveChanges();
        }
        public void Update(LibeyUser libeyUser)
        {
            _context.Entry(libeyUser).State = EntityState.Modified;
            _context.SaveChanges();
        }
        public void Delete(string documentNumber)
        {
            var userToDelete = _context.LibeyUsers.FirstOrDefault(x => x.DocumentNumber == documentNumber);
            if (userToDelete != null)
            {
                _context.LibeyUsers.Remove(userToDelete);
                _context.SaveChanges();
            }
        }
        public List<LibeyUserResponse> GetAllLibeyUsers()
        {
            var q = from libeyUser in _context.LibeyUsers
                    join ubigeo in _context.Ubigeos on libeyUser.UbigeoCode equals ubigeo.UbigeoCode into ubigeoJoin
                    from ubigeo in ubigeoJoin.DefaultIfEmpty()
                    join province in _context.Provinces on ubigeo.ProvinceCode equals province.ProvinceCode into provinceJoin
                    from province in provinceJoin.DefaultIfEmpty()
                    join region in _context.Regions on province.RegionCode equals region.RegionCode into regionJoin
                    from region in regionJoin.DefaultIfEmpty()
                    select new LibeyUserResponse()
                    {
                        DocumentNumber = libeyUser.DocumentNumber,
                        Active = libeyUser.Active,
                        Address = libeyUser.Address,
                        DocumentTypeId = libeyUser.DocumentTypeId,
                        Email = libeyUser.Email,
                        FathersLastName = libeyUser.FathersLastName,
                        MothersLastName = libeyUser.MothersLastName,
                        Name = libeyUser.Name,
                        Password = libeyUser.Password,
                        Phone = libeyUser.Phone,
                        RegionCode = region.RegionDescription,
                        ProvinceCode = province.ProvinceDescription,
                        UbigeoCode = ubigeo.UbigeoDescription
                    };
            return q.ToList();
        }

        public LibeyUserResponse FindResponse(string documentNumber)
        {

            var q = from libeyUser in _context.LibeyUsers
                    join ubigeo in _context.Ubigeos on libeyUser.UbigeoCode equals ubigeo.UbigeoCode into ubigeoJoin
                    from ubigeo in ubigeoJoin.DefaultIfEmpty()
                    join province in _context.Provinces on ubigeo.ProvinceCode equals province.ProvinceCode into provinceJoin
                    from province in provinceJoin.DefaultIfEmpty()
                    join region in _context.Regions on province.RegionCode equals region.RegionCode into regionJoin
                    from region in regionJoin.DefaultIfEmpty()
                    where libeyUser.DocumentNumber.Equals(documentNumber)
                    select new LibeyUserResponse()
                    {
                        DocumentNumber = libeyUser.DocumentNumber,
                        Active = libeyUser.Active,
                        Address = libeyUser.Address,
                        DocumentTypeId = libeyUser.DocumentTypeId,
                        Email = libeyUser.Email,
                        FathersLastName = libeyUser.FathersLastName,
                        MothersLastName = libeyUser.MothersLastName,
                        Name = libeyUser.Name,
                        Password = libeyUser.Password,
                        Phone = libeyUser.Phone,
                        RegionCode = region.RegionDescription,
                        ProvinceCode = province.ProvinceDescription,
                        UbigeoCode = ubigeo.UbigeoDescription
                    };
            var list = q.ToList();
            if (list.Any()) return list.First();
            else return new LibeyUserResponse();
        }
    }
}