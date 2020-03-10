using Microsoft.EntityFrameworkCore;
using NoSleepers.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace NoSleepers.Data
{
    public class NoSleepersDbContext : DbContext
    {
        public DbSet<Story> Stories { get; set; }
        public DbSet<Author> Authors { get; set; }

        public NoSleepersDbContext(DbContextOptions<NoSleepersDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Story>().ToTable("Stories");
            modelBuilder.Entity<Author>().ToTable("Authors");
        }

    }
}
