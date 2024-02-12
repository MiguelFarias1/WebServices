using APICatalogo.Context;
using APICatalogo.Models;
using APICatalogo.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.Repositories.Implementation;

public class CategoryRepository(AppDbContext context, ILogger<CategoryRepository> logger) : IRepository<Category>
{
    public async Task<IEnumerable<Category>> GetAll()
    {
        return await context
            .Categories
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Category> GetById(int id)
    {
        return await context
            .Categories
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<Category> Save(Category category)
    {
        await context.Categories.AddAsync(category);

        await context.SaveChangesAsync();

        return category;
    }

    public async Task<bool> Update(Category category)
    {
        context.Entry(category).State = EntityState.Modified;
        await context.SaveChangesAsync();

        return true;
    }
    public async Task<bool> Delete(int id)
    {
        var category = await context.Categories.FindAsync(id);

        if (category is null) throw new ArgumentNullException(nameof(category));

        context.Categories.Remove(category);

        await context.SaveChangesAsync();

        return true;
    }
}
