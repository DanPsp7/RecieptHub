using Microsoft.AspNetCore.Mvc;
using RecieptHub.BAL.Models;
using RecieptHub.BLL.Interfaces;
using RecieptHub.DTO;

namespace RecieptHub.RecieptHub.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MealController : ControllerBase
{
    private readonly IMealService _service;

    public MealController(IMealService service)
    {
        _service = service;
    }

    /// <summary>Get all meals for a weekly menu day.</summary>
    [HttpGet("day/{menuDayId:int}")]
    public async Task<ActionResult<List<MealDto>>> GetByWeeklyMenuDayId(int menuDayId)
    {
        var list = await _service.GetByWeeklyMenuDayId(menuDayId);
        return Ok(list.Select(MapToDto).ToList());
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<MealDto>> GetById(int id)
    {
        var meal = await _service.GetById(id);
        if (meal == null) return NotFound();
        return Ok(MapToDto(meal));
    }

    [HttpPost]
    public async Task<ActionResult<MealDto>> Create([FromBody] MealCreateDto dto)
    {
        var entity = new Meal
        {
            WeeklyMenuDayId = dto.MenuDayId,
            MealType = (MealType)dto.MealType,
            DishId = dto.DishId
        };
        await _service.Add(entity);
        return CreatedAtAction(nameof(GetById), new { id = entity.Id }, MapToDto(entity));
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> Update(int id, [FromBody] MealUpdateDto dto)
    {
        var entity = await _service.GetById(id);
        if (entity == null) return NotFound();
        if (dto.MealType.HasValue) entity.MealType = (MealType)dto.MealType.Value;
        if (dto.DishId.HasValue) entity.DishId = dto.DishId.Value;
        await _service.Update(entity);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete(int id)
    {
        var entity = await _service.GetById(id);
        if (entity == null) return NotFound();
        await _service.Delete(id);
        return NoContent();
    }

    private static MealDto MapToDto(Meal m)
    {
        return new MealDto
        {
            Id = m.Id,
            MenuDayId = m.WeeklyMenuDayId,
            MealType = (MealTypeDto)m.MealType,
            DishId = m.DishId,
            Dish = m.Dish != null ? new DishDto
            {
                Id = m.Dish.Id,
                Name = m.Dish.Name,
                CookTime = m.Dish.CookTime,
                Recipe = m.Dish.Recipe,
                CalculatedCalories = (decimal)m.Dish.CalculatedCalories,
                CalculatedProteins = (decimal)m.Dish.CalculatedProteins,
                CalculatedFats = (decimal)m.Dish.CalculatedFats,
                CalculatedCarbohydrates = (decimal)m.Dish.CalculatedCarbohydrates
            } : null
        };
    }
}
