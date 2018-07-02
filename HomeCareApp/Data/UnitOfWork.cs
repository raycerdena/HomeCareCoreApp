using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeCareApp.Core.Interface;
using HomeCareApp.DataRepository;

namespace HomeCareApp.Data
{
    public class UnitOfWork : IUnitofWork
    {
        private readonly ApplicationDbContext _context;

        public IApplicationUser User { get; private set; }

        public IApplicationRole Role { get; private set; }

        public IApplicationUserRole UserRole { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;

            User = new ApplicationUserRepository(context);
            Role = new ApplicationRoleRepository(context);
            UserRole = new ApplicationUserRoleRepository(context);
        }

        public void Complete()
        {
            _context.SaveChanges();
        }
    }
}
