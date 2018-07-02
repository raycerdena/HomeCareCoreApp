using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.AspNetCore.Identity;

namespace HomeCareApp.Data
{
    public class ApplicationUser : IdentityUser<int>
    {
        public string Firstname { get; set; }
        public string LastName { get; set; }
        public bool IsActive { get; set; }
        public ICollection<ApplicationUserRole> UserRoles { get; set; }

    }
}