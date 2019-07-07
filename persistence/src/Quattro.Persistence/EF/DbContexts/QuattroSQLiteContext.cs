using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Quattro.Persistence.EF.DbContexts
{
    public class QuattroSQLiteContext : DbContext
    {
        public QuattroSQLiteContext(DbContextOptions<QuattroSQLiteContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
