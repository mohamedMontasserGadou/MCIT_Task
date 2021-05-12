using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCIT_Task.Domain.Entities
{
    public class User: IdentityUser<int>
    {
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
