using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace InvoiceModule.Services.Models
{
    public class Users
    {
        [Key]
        public Int64 Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class UserList
    {
        public UserList()
        {
            userList = new List<Users>();
        }

        public List<Users> userList { get; set; }
    }
}
