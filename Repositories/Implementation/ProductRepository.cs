using APICatalogo.Context;
using APICatalogo.Models;
using APICatalogo.Pagination;

namespace APICatalogo.Repositories.Implementation;

public class ProductRepository(AppDbContext context) : Repository<Product>(context)
{
    public IEnumerable<Product> GetProducts(ProductParameters parameters)
    {
        return GetAllAsync()
            .Result
            .OrderBy(p => p.Name)
            .Skip((parameters.PageNumber - 1) * parameters.PageSize)
            .Take(parameters.PageSize)
            .ToList();
    }
}
