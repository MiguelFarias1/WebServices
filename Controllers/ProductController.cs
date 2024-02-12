using APICatalogo.Models;
using APICatalogo.Repositories.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace APICatalogo.Controllers;

[Route("[controller]")]
[ApiController]
public class ProductController(IRepository<Product> repository, ILogger<ProductController> logger) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<Product>>> GetAll()
    {
        var products = await repository.GetAll();

        if (products is null)
        {
            logger.LogWarning("Products is null!");

            return NotFound();
        }

        return Ok(products);
    }

    [HttpGet("{id:int}", Name = "ObterPorId")]
    public async Task<ActionResult<Product>> GetById([FromRoute] int id)
    {
        var product = await repository.GetById(id);

        if (product is null)
        {
            logger.LogWarning($"Product with id {id} not found!");

            return NotFound("Produto não encontrado!");
        }

        return Ok(product);
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] Product product)
    {
        if (product is null)
        {
            logger.LogWarning("Product invalid!");

            return BadRequest();
        }

        await repository.Save(product);

        return new CreatedAtActionResult(nameof(GetById), "ObterPorId", product, new { id = product.Id });
    }

    [HttpPut()]
    public async Task<ActionResult<Product>> Put([FromBody] Product model)
    {
        var product = await repository.Update(model);

        if (!product) return BadRequest();

        return Ok(product);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete([FromRoute] int id)
    {
        var product = await repository.Delete(id);

        return NoContent();
    }
}
