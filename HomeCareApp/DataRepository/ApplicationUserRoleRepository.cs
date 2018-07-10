using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeCareApp.Core.Interface;
using HomeCareApp.Data;

namespace HomeCareApp.DataRepository
{
    public class ApplicationUserRoleRepository : IApplicationUserRole
    {
        private readonly IApplicationDbContext _context;



        public ApplicationUserRoleRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public ApplicationUserRole GetUserRole(int id)
        {
            return _context.UserRoles.SingleOrDefault(ur => ur.UserId == id);
        }
    }
}
