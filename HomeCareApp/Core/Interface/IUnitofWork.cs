using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeCareApp.Core.Interface
{
    public interface IUnitofWork
    {
        IApplicationUser User { get; }
        IApplicationRole Role { get; }
        IApplicationUserRole UserRole { get; }
        void Complete();
    }
}
