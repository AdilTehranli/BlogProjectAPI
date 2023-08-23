using BlogProject.Core.Entities;
using BlogProject.DAL.Configuration;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace BlogProject.DAL.Context;

public class BlogDBContext : DbContext
{
    public BlogDBContext(DbContextOptions options) : base(options)
    {
    }
    public DbSet<Category> Categories { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //We can use it:  //modelbuilder.applyconfigurationsfromassembly(typeof(CategoryConfiguration).Assembly);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}
