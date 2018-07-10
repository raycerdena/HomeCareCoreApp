using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeCareApp.Core.ViewModels;
using HomeCareApp.Data;
using Microsoft.AspNetCore.Identity;

namespace HomeCareApp.Core.Interface
{
    public interface IApplicationUser
    {
        IEnumerable<UserListView> ListofUser();

        ApplicationUser GetUser(int userid);

    }
}
