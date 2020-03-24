using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NoSleepers.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace NoSleepers.Data.EntityTypeConfigurations
{
    public class StoryEntityTypeConfiguration : IEntityTypeConfiguration<Story>
    {
        public void Configure(EntityTypeBuilder<Story> builder)
        {
            builder.ToTable("Stories");
            builder.HasKey(x => x.Id);

            builder.HasOne(s => s.Author)
                   .WithMany(a => a.Stories)
                   .HasForeignKey(s => s.AuthorId);

            builder.OwnsMany(x => x.Ratings, x =>
            {
                x.WithOwner().HasForeignKey(x => x.UserId);
                x.WithOwner().HasForeignKey(x => x.StoryId);
                x.Property(x => x.Score).IsConcurrencyToken().ValueGeneratedOnAddOrUpdate();
                x.HasKey(y => new { y.StoryId, y.UserId });
                x.ToTable("Ratings");

            });
            builder.OwnsMany(x => x.Favorites, x =>
            {
                x.WithOwner().HasForeignKey(x => x.StoryId);
                x.HasKey(y => new { y.StoryId, y.UserId });
                x.ToTable("Favorites");
            });
        }
    }
}
