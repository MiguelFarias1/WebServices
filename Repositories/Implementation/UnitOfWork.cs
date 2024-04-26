using APICatalogo.Context;
using APICatalogo.Models;
using APICatalogo.Repositories.Abstractions;

namespace APICatalogo.Repositories.Implementation;

public class UnitOfWork(AppDbContext context, 
    IRepository<Product> productRepository, 
    IRepository<Category> categoryRepository) : IUnitOfWork
{
    public IRepository<Product> ProductRepository { get; } = productRepository;
    public IRepository<Category> CategoryRepository { get; } = categoryRepository;

    public async Task CommitAsync()
    {
        await context.SaveChangesAsync();
    }

    public async Task DisposeAsync()
    {
        await context.DisposeAsync();
    }
}
