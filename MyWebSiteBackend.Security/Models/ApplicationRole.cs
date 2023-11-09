using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace MyWebSiteBackend.Security.Models
{
    public class ApplicationRole : IdentityRole<int>
    {
        public ApplicationRole()
        {
            ApplicationUserRoles=new List<ApplicationUserRole>();
        }

        public string Description { get; set; }
        public ICollection<ApplicationUserRole> ApplicationUserRoles { get; set; }
    }
}