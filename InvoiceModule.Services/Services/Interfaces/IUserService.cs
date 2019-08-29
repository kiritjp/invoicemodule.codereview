using InvoiceModule.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvoiceModule.Services.Services.Interfaces
{
    public interface IUserService
    {
        IEnumerable<Users> GetUsers();
    }
}
