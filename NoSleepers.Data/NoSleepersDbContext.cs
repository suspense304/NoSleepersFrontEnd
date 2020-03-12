using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NoSleepers.Core;
using NoSleepers.Data.EntityTypeConfigurations;
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
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new AuthorEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new StoryEntityTypeConfiguration());
        }

    }
}
