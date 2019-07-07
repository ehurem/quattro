using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quattro.Persistence.EF
{
    public class QuattroDbContext : DbContext
    {
        public virtual DbSet<Entities.User> Users { get; set; }

        public QuattroDbContext(DbContextOptions<QuattroDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Entities.User>().HasKey(u => u.Id);
        }
    }
}
