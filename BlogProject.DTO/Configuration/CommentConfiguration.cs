using BlogProject.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogProject.DAL.Configuration;

public class CommentConfiguration : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.Property(c => c.Text).IsRequired();
        builder.Property(c=>c.CreatedTime).HasDefaultValueSql("getutcdate()") ;
        builder.HasOne(b => b.Blog).WithMany(c => c.Comments).HasForeignKey(b => b.BlogId).OnDelete(DeleteBehavior.NoAction);
        builder.HasOne(a=>a.AppUser).WithMany(c => c.Comments).HasForeignKey(a => a.AppUserId);
        builder.HasOne(c=>c.Parent).WithMany(c=>c.Children).HasForeignKey(c => c.ParentId);
    }
}
