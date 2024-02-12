using APICatalogo.Context;
using APICatalogo.Models;
using APICatalogo.Repositories.Abstractions;

namespace APICatalogo.Repositories.Implementation;

public class ProductRepository(AppDbContext context) : IRepository<Product>
{
    public Task<IEnumerable<Product>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<Product> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Product> Save(Product entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Update(Product entity)
    {
        throw new NotImplementedException();
    }
    public Task<bool> Delete(int id)
    {
        throw new NotImplementedException();
    }
}
