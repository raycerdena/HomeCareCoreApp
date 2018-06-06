using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.AspNetCore.Identity;

namespace HomeCareApp.Data
{
    public class ApplicationUser : IdentityUser<int>
    {
        public string Firstname { get; set; }
        public string LastName { get; set; }
        public ICollection<ApplicationRole> Roles { get; set; }
        public int RoleId { get; set; }

        public ApplicationUser()
        {
            Roles = new Collection<ApplicationRole>();
        }


    }
}