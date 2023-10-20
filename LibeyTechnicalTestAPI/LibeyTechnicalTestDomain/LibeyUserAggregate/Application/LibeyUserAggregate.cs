﻿using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Domain;
namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Application
{
    public class LibeyUserAggregate : ILibeyUserAggregate
    {
        private readonly ILibeyUserRepository _repository;
        public LibeyUserAggregate(ILibeyUserRepository repository)
        {
            _repository = repository;
        }
        public void Create(UserUpdateorCreateCommand command)
        {
            var libeyUser = new LibeyUser(
                            command.DocumentNumber,
                            command.DocumentTypeId,
                            command.Name,
                            command.FathersLastName,
                            command.MothersLastName,
                            command.Address,
                            command.UbigeoCode,
                            command.Phone,
                            command.Email,
                            command.Password
                        );

            _repository.Create(libeyUser);
        }
        public void Update(UserUpdateorCreateCommand command)
        {
            var libeyUser = new LibeyUser(
                command.DocumentNumber, 
                command.DocumentTypeId, 
                command.Name, 
                command.FathersLastName, 
                command.MothersLastName,            
                command.Address, 
                command.UbigeoCode, 
                command.Phone, 
                command.Email, 
                command.Password);
            _repository.Update(libeyUser);
        }
        public void Delete(string documentNumber)
        {
            _repository.Delete(documentNumber);
        }
        public List<LibeyUserResponse> GetAllLibeyUsers()
        {
            return _repository.GetAllLibeyUsers();
        }
        public LibeyUserResponse FindResponse(string documentNumber)
        {
            var row = _repository.FindResponse(documentNumber);
            return row;
        }
    }
}