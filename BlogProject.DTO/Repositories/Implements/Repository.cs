using BlogProject.Core.Entities.Commons;
using BlogProject.DAL.Context;
using BlogProject.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BlogProject.DAL.Repositories.Implements;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity, new()
{
    readonly BlogDBContext _context;

    public Repository(BlogDBContext context)
    {
        _context = context;
    }

    public DbSet<TEntity> Table => _context.Set<TEntity>();

    public async Task CreateAsync(TEntity entity)
    {
         await Table.AddAsync(entity);
    }

    public async Task DeleteAsync(TEntity entity)
    {
       _context.Remove(entity);
    }

    public  IQueryable<TEntity> FindAll(Expression<Func<TEntity, bool>> expression)
    {
       return  Table.Where(expression);
    }

    public async Task<TEntity> FindByIdAsync(int id)
    {
       return await Table.FindAsync(id);
    }

    public IQueryable<TEntity> GetAll(params string[] includes)
    {
        var query= Table.AsQueryable();
        foreach (var item in includes)
        {
            query = query.Include(item);
        }
        return query;
    }

    public async Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> expression)
    {
        return await Table.SingleOrDefaultAsync(expression);
    }

    public async Task<bool> IsExist(Expression<Func<TEntity, bool>> expression)
    {
        return await Table.AnyAsync(expression);
    }

    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }

}

