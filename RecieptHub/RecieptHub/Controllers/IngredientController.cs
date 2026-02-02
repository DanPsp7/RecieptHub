using Microsoft.AspNetCore.Mvc;
using RecieptHub.BAL.Models;
using RecieptHub.BLL.Interfaces;
using RecieptHub.DTO;

namespace RecieptHub.RecieptHub.Controllers;

[ApiController]
[Route("api/[controller]")]
public class IngredientController : ControllerBase
{
    private readonly IIngredientService _ingredientService;

    public IngredientController(IIngredientService ingredientService)
    {
        _ingredientService = ingredientService;
    }

    [HttpGet]
    public async Task<ActionResult<List<Ingredient>>> GetIngredients()
    {
        var list = await _ingredientService.GetIngredients();
        return Ok(list);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Ingredient>> GetById(int id)
    {
        var ingredient = await _ingredientService.GetById(id);
        if (ingredient == null) return NotFound();
        return Ok(ingredient);
    }

    [HttpPost]
    public async Task Create([FromBody] IngredientCreateDto ingredient)
    {
        var entity = new Ingredient
        {
            Name = ingredient.Name,
            Calories = ingredient.Calories,
            Fats = ingredient.Fats,
            Proteins = ingredient.Proteins,
            Carbohydrates = ingredient.Carbohydrates,
            
        };


        await _ingredientService.AddIngredient(entity);
        
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> Update(int id, [FromBody] Ingredient ingredient)
    {
        if (id != ingredient.Id) return BadRequest();
        await _ingredientService.UpdateIngredient(ingredient);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete(int id)
    {
        await _ingredientService.DeleteIngredient(id);
        return NoContent();
    }
}