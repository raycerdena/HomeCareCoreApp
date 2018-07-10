using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeCareApp.Core.Interface;
using HomeCareApp.Core.Models;
using HomeCareApp.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HomeCareApp.DataRepository
{
    public class ApplicationRoleRepository : IApplicationRole
    {
        private IApplicationDbContext _context;



        public ApplicationRoleRepository(IApplicationDbContext context)
        {
            _context = context;
        }



        public List<SelectListItem> GetRoles()
        {

            var role = _context.Roles.Select(r => new SelectListItem
            {
                Text = r.Name,
                Value = r.Id.ToString()
            }).ToList();

            return role;
        }




        public void Add(ApplicationRole role)
        {
            _context.Roles.Add(role);


        }




    }
}
