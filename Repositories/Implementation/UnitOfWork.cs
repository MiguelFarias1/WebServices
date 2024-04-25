using APICatalogo.Context;
using APICatalogo.Models;
using APICatalogo.Repositories.Abstractions;

namespace APICatalogo.Repositories.Implementation;

public class UnitOfWork(AppDbContext context,
    IRepository<Product> productRepository,
    IRepository<Category> categoryRepository) : IUnitOfWork
{
    public IRepository<Product> ProductRepository
    {
        get
        {
            return productRepository ?? new ProductRepository(context);
        }
    }

    public IRepository<Category> CategoryRepository
    {
        get
        {
            return categoryRepository ?? new CategoryRepository(context);
        }
    }

    public async Task CommitAsync()
    {
        await context.SaveChangesAsync();
    }

    public async Task DisposeAsync()
    {
        await context.DisposeAsync();
    }
}
