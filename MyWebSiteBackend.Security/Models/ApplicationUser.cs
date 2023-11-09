using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace MyWebSiteBackend.Security.Models
{
    public class ApplicationUser : IdentityUser<int>
    {
        public ApplicationUser()
        {
            ApplicationUserRoles=new List<ApplicationUserRole>();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PictureUrl { get; set; }
        public string MobileNumber { get; set; }
        public bool IsMobileConfirmed { get; set; }
        public ICollection<ApplicationUserRole> ApplicationUserRoles { get; set; }
    }
}