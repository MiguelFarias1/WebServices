using APICatalogo.Context;
using APICatalogo.Models;

namespace APICatalogo.Repositories.Implementation;

public class ProductRepository(AppDbContext context) : Repository<Product>(context)
{

}
