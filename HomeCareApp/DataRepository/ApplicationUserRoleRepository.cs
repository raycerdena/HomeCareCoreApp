using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeCareApp.Core.Interface;

namespace HomeCareApp.DataRepository
{
    public class ApplicationUserRoleRepository : IApplicationUserRole
    {
        private readonly IApplicationDbContext _context;



        public ApplicationUserRoleRepository(IApplicationDbContext context)
        {
            _context = context;
        }
    }
}
