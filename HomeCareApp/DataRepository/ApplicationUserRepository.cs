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



        public IEnumerable<UserListView> ListofUser()
        {
            var user = _context.Users.Include(u => u.UserRoles)
                      .ThenInclude(ur => ur.Role)
                      .Select(r => new UserListView
                      {
                         FirstName= r.Firstname,
                        LastName=  r.LastName,
                        UserName=  r.UserName,
                        PhoneNumber=  r.PhoneNumber,
                        Email=  r.Email,
                       IsActive=   r.IsActive,
                        Role=  r.UserRoles.Select(ur=>ur.Role.Name).SingleOrDefault()

                      })
                    .ToList();

            return user;

            //var userList = (from user in _context.Users
            //                select new
            //                {
            //                    UserId = user.Id,
            //                    Username = user.UserName,
            //                    user.Firstname,
            //                    user.LastName,
            //                    user.PhoneNumber,
            //                    user.Email,
            //                    user.IsActive,
            //                    Role = (from userRole in user.UserRoles //[AspNetUserRoles]
            //                            join role in _context.Roles //[AspNetRoles]//
            //                            on userRole.RoleId
            //                            equals role.Id
            //                            select role.Name).ToList()
            //                }).ToList();

            //var userlistmodel = userList.Select(p => new UserListView
            //{

            //    UserName = p.Username,
            //    FirstName = p.Firstname,
            //    LastName = p.LastName,
            //    Email = p.Email,
            //    PhoneNumber = p.PhoneNumber,
            //    Role = string.Join(",", p.Role),
            //    IsActive = p.IsActive
            //}).ToList();

           // return userlistmodel;
            
        }

    }
}
