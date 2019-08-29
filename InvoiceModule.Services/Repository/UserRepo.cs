using InvoiceModule.Services.DBContext;
using InvoiceModule.Services.Models;
using InvoiceModule.Services.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InvoiceModule.Services.Repository
{
    public class UserRepo : IUserRepo
    {
        public List<Users> GetUsers()
        {
            using (InvoiceModuleContext dbContext = new InvoiceModuleContext())
            {
                var users = dbContext.users;
                return users.ToList();
            }
        }
    }
}
