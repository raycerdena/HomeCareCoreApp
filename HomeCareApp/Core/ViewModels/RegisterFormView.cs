using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeCareApp.Data;

namespace HomeCareApp.Core.ViewModels
{
    public class RegisterFormView
    {
        public string UserName { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmedPassword { get; set; }
        public string PhoneNumber { get; set; }
        public int RoleId { get; set; }
        public IEnumerable<ApplicationRole> Roles { get; set; }

    }

}
