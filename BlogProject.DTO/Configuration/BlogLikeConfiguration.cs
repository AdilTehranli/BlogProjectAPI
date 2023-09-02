using BlogProject.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogProject.DAL.Configuration;

public class BlogLikeConfiguration : IEntityTypeConfiguration<BlogLike>
{
    public void Configure(EntityTypeBuilder<BlogLike> builder)
    {
        builder.HasOne(b=>b.Blog).WithMany(b=>b.Likes).HasForeignKey(b=>b.BlogId).OnDelete(DeleteBehavior.NoAction);
        builder.HasOne(b => b.AppUser).WithMany(b => b.Likes).HasForeignKey(b => b.AppUserId);
        builder.Property(b=>b.Reaction).IsRequired();
        builder.Ignore(b => b.IsDeleted);
    }
}
