using APICatalogo.DTOs;
using APICatalogo.Models;
using APICatalogo.Repositories.Abstractions;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace APICatalogo.Controllers;

[Route("[controller]")]
[ApiController]
public class ProductController(IUnitOfWork uof, ILogger<ProductController> logger, IMapper mapper) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<ProductDTO>>> GetAll()
    {
        var products = await uof.ProductRepository.GetAllAsync();

        if (products is null)
        {
            logger.LogWarning("Products is null!");

            return NotFound();
        }

        var productsDTO = mapper.Map<ProductDTO>(products);

        return Ok(productsDTO);
    }

    [HttpGet("{id:int}", Name = "ObterPorId")]
    public async Task<ActionResult<ProductDTO>> GetById([FromRoute] int id)
    {
        var product = await uof.ProductRepository.GetByIdAsync(x => x.CategoryId == id);

        if (product is null)
        {
            logger.LogWarning($"Product with id {id} not found!");

            return NotFound("Produto não encontrado!");
        }

        var productDTO = mapper.Map<ProductDTO>(product);

        return Ok(productDTO);
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] ProductDTO productDTO)
    {
        if (productDTO is null)
        {
            logger.LogWarning("Product invalid!");

            return BadRequest();
        }

        var product = mapper.Map<Product>(productDTO);

        var newProduct = await uof.ProductRepository.SaveAsync(product);

        return new CreatedAtActionResult(nameof(GetById), "ObterPorId", product, new { id = newProduct.Id });
    }

    [HttpPut()]
    public async Task<ActionResult<ProductDTO>> Put([FromBody] ProductDTO productDTO)
    {
        var product = mapper.Map<Product>(productDTO);

        await uof.ProductRepository.UpdateAsync(product);

        return Ok(product);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete([FromRoute] int id)
    {
        var product = await uof.ProductRepository.GetByIdAsync(x => x.Id == id);

        if (product is null)
        {
            return NotFound("Produto não encontrado!");
        }

        await uof.ProductRepository.DeleteAsync(product);

        return NoContent();
    }
}
