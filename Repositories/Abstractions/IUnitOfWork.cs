using APICatalogo.Models;
using APICatalogo.Repositories.Implementation;

namespace APICatalogo.Repositories.Abstractions;

public interface IUnitOfWork
{
    public IRepository<Product> ProductRepository { get; }
    public IRepository<Category> CategoryRepository { get; }
    Task CommitAsync();
    Task DisposeAsync();
}
