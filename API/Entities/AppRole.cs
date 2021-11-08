using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace API.Entities
{
    public class AppRole : IdentityRole<int>
    {
        public AppRole()
        {
        }

        public AppRole(string roleName) : base(roleName) { }
        public ICollection<AppUserRole> UserRoles { get; set; }
    }
}