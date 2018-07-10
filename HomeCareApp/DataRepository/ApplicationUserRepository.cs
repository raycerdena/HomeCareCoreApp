using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeCareApp.Core.Interface;
using HomeCareApp.Core.ViewModels;
using HomeCareApp.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HomeCareApp.DataRepository
{
    public class ApplicationUserRepository : IApplicationUser
    {
        private readonly IApplicationDbContext _context;
        public ApplicationUserRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public ApplicationUser GetUser(int userid)
        {
            return _context.Users.SingleOrDefault(u => u.Id == userid);
        }


        public IEnumerable<UserListView> ListofUser()
        {
            var user = _context.Users.Include(u => u.UserRoles)
                      .ThenInclude(ur => ur.Role)
                      .Select(r => new UserListView
                      {
                          UserId = r.Id,
                          FirstName = r.Firstname,
                          LastName = r.LastName,
                          UserName = r.UserName,
                          PhoneNumber = r.PhoneNumber,
                          Email = r.Email,
                          IsActive = r.IsActive,
                          Role = r.UserRoles.Select(ur => ur.Role.Name).SingleOrDefault()

                      })
                    .ToList();

            return user;


        }

    }
}
