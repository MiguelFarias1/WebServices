using APICatalogo.Context;
using APICatalogo.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace APICatalogo.Repositories.Implementation;

public class Repository<T>(AppDbContext context) : IRepository<T> where T : class
{
    public async Task<IEnumerable<T>> GetAllAsync()
    {
        var entities = await context
            .Set<T>()
            .AsNoTracking()
            .ToListAsync();

        return entities;
    }

    public async Task<T> GetByIdAsync(Expression<Func<T, bool>> predicate)
    {
        var entity = await context
            .Set<T>()
            .AsNoTracking()
            .FirstOrDefaultAsync(predicate);

        return entity;
    }

    public async Task<T> SaveAsync(T entity)
    {
        await context.Set<T>().AddAsync(entity);

        await context.SaveChangesAsync();

        return entity;
    }

    public async Task<bool> UpdateAsync(T entity)
    {
        await context.Set<T>().AddAsync(entity);

        await context.SaveChangesAsync();

        return true;
    }
    public async Task<bool> DeleteAsync(T entity)
    {
        context.Set<T>().Remove(entity);

        await context.SaveChangesAsync();

        return true;
    }
}
