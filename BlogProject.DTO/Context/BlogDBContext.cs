using BlogProject.Core.Entities;
using BlogProject.DAL.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace BlogProject.DAL.Context;

public class BlogDBContext : IdentityDbContext
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
