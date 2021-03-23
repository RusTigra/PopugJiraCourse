using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaskBoard.Database.Models;

namespace TaskBoard.Database
{
    public class DatabaseContext : DbContext
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
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PopugTask>(x =>
            {
                x.Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
                x.Property(p => p.Content).IsRequired();
                x.Property(p => p.Responsible).IsRequired(false);
                x.Property(p => p.Status).IsRequired();
                x.HasKey(p => p.Id);
            });
        }

        #region DBSETs
        public DbSet<PopugTask> PopugTasks { get; set; }
        #endregion DBSETs

    }
}
