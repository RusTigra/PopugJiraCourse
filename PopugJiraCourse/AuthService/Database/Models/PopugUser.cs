using System;
using Microsoft.AspNetCore.Identity;

namespace AuthService.Database.Models
{
    public class PopugUser : IdentityUser
    {
        public Guid UniqueKey { get; set; }
    }
}
