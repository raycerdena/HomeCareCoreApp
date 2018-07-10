using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeCareApp.Core.Models;
using HomeCareApp.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HomeCareApp.Core.Interface
{
    public interface IApplicationRole
    {
        //ApplicationRole IsRoleExist { get; set; }
        List<SelectListItem> GetRoles();
        void Add(ApplicationRole applicationRole);

    }
}
