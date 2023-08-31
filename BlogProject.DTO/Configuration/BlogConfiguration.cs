using BlogProject.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogProject.DAL.Configuration;

public class BlogConfiguration : IEntityTypeConfiguration<Blog>
{
    public void Configure(EntityTypeBuilder<Blog> builder)
    {
       builder.Property(b=>b.Title).IsRequired().HasMaxLength(255);
       builder.Property(b=>b.Description).IsRequired().HasMaxLength(255);
        builder.Property(b => b.CoverImageUrl).IsRequired();
        builder.Property(b => b.ViewewCount).HasDefaultValue(0);
        builder.Property(b=>b.CreatedTime).HasDefaultValueSql("getutcdate()");
        builder.HasOne(b => b.AppUser).WithMany(u => u.Blogs).HasForeignKey(b => b.AppUserId);

    }
}
