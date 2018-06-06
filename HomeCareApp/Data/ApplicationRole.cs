using Microsoft.AspNetCore.Identity;

namespace HomeCareApp.Data
{
    public class ApplicationRole : IdentityRole<int>
    {
        public string Description { get; set; }

    }
}