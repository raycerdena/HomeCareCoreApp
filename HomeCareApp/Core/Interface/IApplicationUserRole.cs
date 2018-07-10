using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeCareApp.Data;

namespace HomeCareApp.Core.Interface
{
    public interface IApplicationUserRole
    {
        ApplicationUserRole GetUserRole(int id);
    }
}
