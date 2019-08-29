using InvoiceModule.Services.Models;
using InvoiceModule.Services.Repository.Interfaces;
using InvoiceModule.Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InvoiceModule.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepo _userRepo;

        public UserService(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }

        public IEnumerable<Users> GetUsers()
        {
            return _userRepo.GetUsers();
        }
    }
}
