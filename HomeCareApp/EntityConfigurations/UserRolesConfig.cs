using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeCareApp.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeCareApp.EntityConfigurations
{
    public class UserRolesConfig : IEntityTypeConfiguration<ApplicationUserRole>
    {
        public void Configure(EntityTypeBuilder<ApplicationUserRole> builder)
        {
            builder.ToTable("UserRole");
            builder.HasKey(ur => new { ur.UserId, ur.RoleId });
        
            builder.HasOne(u => u.User).WithMany(x => x.UserRoles).HasForeignKey(r => r.UserId).IsRequired();
            builder.HasOne(u => u.Role).WithMany(x => x.UserRoles).HasForeignKey(r => r.RoleId).IsRequired();

        }
    }
}
