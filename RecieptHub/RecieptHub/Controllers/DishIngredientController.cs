using Microsoft.AspNetCore.Mvc;
using RecieptHub.BAL.Models;
using RecieptHub.BLL.Interfaces;
using RecieptHub.DTO;

namespace RecieptHub.RecieptHub.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DishIngredientController : ControllerBase
{
    private readonly IDishIngredientService _service;

    public DishIngredientController(IDishIngredientService service)
    {
        _service = service;
    }

   
    [HttpGet("dish/{dishId:int}")]
    public async Task<List<DishIngredient>> GetByDishId(int dishId)
    {
        return await _service.GetByDishId(dishId);
        
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<DishIngredientDto>> GetById(int id)
    {
        var item = await _service.GetById(id);
        if (item == null) return NotFound();
        return Ok(MapToDto(item));
    }

  
    [HttpPost]
    public async Task<ActionResult<DishIngredientDto>> Create([FromBody] DishIngredientCreateDto dto)
    {
        var entity = new DishIngredient
        {
            DishId = dto.DishId,
            IngredientId = dto.IngredientId,
            QuantityGrams = dto.QuantityGrams
        };
        await _service.Add(entity);
        return CreatedAtAction(nameof(GetById), new { id = entity.Id }, MapToDto(entity));
    }

    [HttpPut("{id:int}")]
    public async Task Update(int id, [FromBody] DishIngredientUpdateDto dto)
    {
        var entity = await _service.GetByDishId(id);
        
        
        entity.QuantityGrams = dto.QuantityGrams;
        
        await _service.Update(entity);
       
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete(int id)
    {
        var entity = await _service.GetById(id);
        if (entity == null) return NotFound();
        await _service.Delete(id);
        return NoContent();
    }

    private static DishIngredientDto MapToDto(DishIngredient di)
    {
        return new DishIngredientDto
        {
            Id = di.Id,
            DishId = di.DishId,
            IngredientId = di.IngredientId,
            IngredientName = di.Ingredient?.Name,
            QuantityGrams = di.QuantityGrams,
            CaloriesInDish = di.CaloriesInDish,
            ProteinsInDish = di.ProteinsInDish,
            FatsInDish = di.FatsInDish,
            CarbohydratesInDish = di.CarbohydratesInDish
        };
    }
}
