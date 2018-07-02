using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeCareApp.Data;
using Microsoft.EntityFrameworkCore;


namespace HomeCareApp.Core.Interface
{
    public interface IApplicationDbContext
    {
        DbSet<ApplicationUser> Users { get; set; }
        DbSet<ApplicationRole> Roles { get; set; }
        DbSet<ApplicationUserRole> UserRoles { get; set; }
    }
}
