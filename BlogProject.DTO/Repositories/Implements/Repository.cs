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
        _context.SaveChanges();
    }

    public  IQueryable<TEntity> FindAll(Expression<Func<TEntity, bool>> expression, params string[] includes)
    {
       return  _getIncludec(Table,includes).Where(expression);
    }

    public async Task<TEntity> FindByIdAsync(int id, params string[] includes)
    {
        if(includes.Length == 0)
        {
            return await Table.FindAsync(id);
        }
        var query = Table.AsQueryable();
        return await _getIncludec(query, includes).SingleOrDefaultAsync(t=>t.Id==id);
    }

    public IQueryable<TEntity> GetAll(params string[] includes)
    {
        var query= Table.AsQueryable();
        return _getIncludec(query, includes);
    }

    public async Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> expression, params string[] includes)
    {
        return await _getIncludec(Table,includes).SingleOrDefaultAsync(expression);
    }

    public async Task<bool> IsExistAsync(Expression<Func<TEntity, bool>> expression)
    {
        return await Table.AnyAsync(expression);
    }

    public async void ReverceSoftDelete(TEntity entity)
    {
      entity.IsDeleted = false;
    }

    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }

    public void SoftDelete(TEntity entity)
    {
      entity.IsDeleted = true;
    }
    IQueryable<TEntity> _getIncludec(IQueryable<TEntity> query, params string[] includes)
    {
        foreach (var item in includes)
        {
            query = query.Include(item);
        }
        return query;
    }
}

