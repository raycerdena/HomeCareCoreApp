using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HomeCareApp.Core.ViewModels
{
    public class RoleFormView
    {
        [Required]

        public string RoleName { get; set; }

        public string Description { get; set; }
    }
}
