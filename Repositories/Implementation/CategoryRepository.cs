using APICatalogo.Context;
using APICatalogo.Models;

namespace APICatalogo.Repositories.Implementation;

public class CategoryRepository(AppDbContext context, ILogger<CategoryRepository> logger = null) : Repository<Category>(context)
{

}
