using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using HomeCareApp.EntityConfigurations;

namespace HomeCareApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new UsersConfig());
            builder.ApplyConfiguration(new UserLoginConfig());
            builder.ApplyConfiguration(new RolesConfig());
            builder.ApplyConfiguration(new UserClaimsConfig());
            builder.ApplyConfiguration(new RoleClaimsConfig());
            builder.ApplyConfiguration(new UserRolesConfig());
            builder.ApplyConfiguration(new UserTokensConfig());

        }



    }


}