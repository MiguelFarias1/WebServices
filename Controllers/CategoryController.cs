using APICatalogo.Filters;
using APICatalogo.Models;
using APICatalogo.Repositories.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace APICatalogo.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoryController(IRepository<Category> repository, ILogger logger) : ControllerBase
{
    [HttpGet]
    [ServiceFilter(typeof(ApiLoggerFilter))]
    public async Task<ActionResult<List<Category>>> GetAll()
    {
        var categories = await repository.GetAll();

        return Ok(categories);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Category>> GetById([FromRoute] int id)
    {
        var category = await repository.GetById(id);

        if (category is null) return NotFound("Produto não encontrado!");

        return Ok(category);
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] Category category)
    {
        if (category is null) return BadRequest();

        await repository.Save(category);

        return new CreatedAtActionResult(nameof(GetById), "ObterPorId", category, new { id = category.Id });
    }

    [HttpPut()]
    public async Task<ActionResult<Category>> Put([FromBody] Category model)
    {
        var category = await repository.Update(model);

        return Ok(category);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete([FromRoute] int id)
    {
        var category = await repository.Delete(id);

        return NoContent();
    }
}
