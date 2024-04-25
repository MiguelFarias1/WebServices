using APICatalogo.DTOs;
using APICatalogo.Filters;
using APICatalogo.Models;
using APICatalogo.Repositories.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace APICatalogo.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoryController(IUnitOfWork uof, ILogger<CategoryController> logger) : ControllerBase
{
    [HttpGet]
    [ServiceFilter(typeof(ApiLoggerFilter))]
    public async Task<ActionResult<IEnumerable<Category>>> GetAll()
    {
        var categories = await uof.CategoryRepository.GetAllAsync();

        return Ok(categories);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<CategoryDTO>> GetById([FromRoute] int id)
    {
        var category = await uof.CategoryRepository.GetByIdAsync(x => x.Id == id);

        if (category is null) return NotFound("Produto não encontrado!");

        var categoryDTO = new CategoryDTO
        {
            CategoryId = category.Id,
            ImageUrl = category.ImageUrl,
            Name = category.Name
        };

        return Ok(categoryDTO);
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] Category category)
    {
        if (category is null) return BadRequest();

        await uof.CategoryRepository.SaveAsync(category);

        return new CreatedAtActionResult(nameof(GetById), "ObterPorId", category, new { id = category.Id });
    }

    [HttpPut()]
    public async Task<ActionResult<Category>> Put([FromBody] Category model)
    {
        var category = await uof.CategoryRepository.UpdateAsync(model);

        return Ok(category);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete([FromRoute] int id)
    {
        var category = await uof.CategoryRepository.GetByIdAsync(x => x.Id == id);

        if (category is null) return NotFound("Categoria não encontrada!");


        await uof.CategoryRepository.DeleteAsync(category);

        return NoContent();
    }
}
