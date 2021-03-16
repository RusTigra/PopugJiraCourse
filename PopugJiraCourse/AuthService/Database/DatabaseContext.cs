using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthService.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace AuthService.Database
{
    public sealed class DatabaseContext : IdentityDbContext<PopugUser>
    {
        /// <summary>
        /// Необходимо для design-time и создания миграций
        /// </summary>
        public DatabaseContext()
        {
        }

        public DbContextOptions Options { get; }

        public DatabaseContext(DbContextOptions options) : base(options)
        {
            Options = options;
            Database.EnsureCreated();
        }
    }
}
