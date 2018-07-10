using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeCareApp.Core.Models;
using HomeCareApp.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HomeCareApp.Core.ViewModels
{
    public class CreateUserFormView
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmedPassword { get; set; }
        public string PhoneNumber { get; set; }
        public int RoleId { get; set; }
        public bool IsActive { get; set; }
        public List<SelectListItem> ApplicationRoles { get; set; }


    }

}
