﻿using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces
{
    public interface ILibeyUserAggregate
    {
        LibeyUserResponse FindResponse(string documentNumber);
        void Create(UserUpdateorCreateCommand command);
        List<LibeyUserResponse> GetAllLibeyUsers();
        void Update(UserUpdateorCreateCommand command);
        void Delete(string documentNumber);
    }
}