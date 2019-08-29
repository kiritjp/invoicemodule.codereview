using InvoiceModule.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvoiceModule.Services.Repository.Interfaces
{
    public interface IUserRepo
    {
        List<Users> GetUsers();
    }
}
