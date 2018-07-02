using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeCareApp.Core.Interface;
using HomeCareApp.Data;

namespace HomeCareApp.DataRepository
{
    public class ApplicationRoleRepository : IApplicationRole
    {
        private IApplicationDbContext _context;



        public ApplicationRoleRepository(IApplicationDbContext context)
        {
            _context = context;
        }



        public IEnumerable<ApplicationRole> GetRoles()
        {
            return _context.Roles.ToList();
        }

        public void Add(ApplicationRole role)
        {
            _context.Roles.Add(role);


        }


    }
}
