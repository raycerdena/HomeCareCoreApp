using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace HomeCareApp.Data
{
    public class ApplicationRole : IdentityRole<int>
    {
        public string Description { get; set; }

        public ICollection<ApplicationUserRole> UserRoles { get; set; }
    }
}