using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Domain;

namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces
{
    public interface ILibeyUserRepository
    {
        List<LibeyUserResponse> GetAllLibeyUsers();
        LibeyUserResponse FindResponse(string documentNumber);
        void Create(LibeyUser libeyUser);
        void Update(LibeyUser libeyUser);
        void Delete(string documentNumber);
    }
}
