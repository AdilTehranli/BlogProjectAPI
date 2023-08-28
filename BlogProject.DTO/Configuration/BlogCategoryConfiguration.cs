using BlogProject.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogProject.DAL.Configuration;

public class BlogCategoryConfiguration : IEntityTypeConfiguration<BlogCategory>
{
    public void Configure(EntityTypeBuilder<BlogCategory> builder)
    {
        builder.HasOne(b => b.Blog)
             .WithMany(b => b.BlogCategories)
             .HasForeignKey(bc => bc.BlogId);
        builder.HasOne(bc => bc.Category)
            .WithMany(c=>c.BlogCategories)
            .HasForeignKey(bc => bc.CategoryId);
        builder.Ignore(i => i.IsDeleted);
    }
}
