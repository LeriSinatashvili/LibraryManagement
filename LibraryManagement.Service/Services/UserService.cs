using LibraryManagement.Service.Commands;
using LibraryManagement.Service.Repository;
using Microsoft.EntityFrameworkCore.Update.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Service.Services
{
    public class UserService
    {
        private readonly IUserRepository repository;

        public UserService(IUserRepository repository)
        {
            this.repository = repository;
        }


        public void RegisterUser(RegisterUserCommand command)
        {
            command.Validate();
            bool privateNumberExists = repository.ExistPrivateNumber(command.PrivateNumber);
            if (privateNumberExists)
            {
                throw new DomainException("Private number already exists");
            }

            repository.CreateUser(command.privateNumber);
        }
    }
}
