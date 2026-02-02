using System;
using Microsoft.AspNetCore.Mvc;
using RecieptHub.BAL.Models;
using RecieptHub.BLL.Interfaces;
using RecieptHub.DTO;

namespace RecieptHub.RecieptHub.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WeeklyMenuController : ControllerBase
{
    private readonly IWeeklyMenuService _menuService;
    private readonly IWeeklyMenuDayService _dayService;

    public WeeklyMenuController(IWeeklyMenuService menuService, IWeeklyMenuDayService dayService)
    {
        _menuService = menuService;
        _dayService = dayService;
    }

    /// <summary>Get all weekly menus.</summary>
    [HttpGet]
    public async Task<ActionResult<List<WeeklyMenuDto>>> GetAll()
    {
        var list = await _menuService.GetAll();
        return Ok(list.Select(MapToDto).ToList());
    }

    /// <summary>Get the currently active weekly menu.</summary>
    [HttpGet("active")]
    public async Task<ActionResult<WeeklyMenuDto?>> GetActive()
    {
        var menu = await _menuService.GetActive();
        if (menu == null) return NotFound();
        return Ok(MapToDto(menu));
    }

    /// <summary>Create a new weekly menu (creates 7 empty days: Monday–Sunday).</summary>
    [HttpPost]
    public async Task<ActionResult<WeeklyMenuDto>> Create([FromBody] WeeklyMenuCreateDto dto)
    {
        var menu = new WeeklyMenu
        {
            Name = dto.Name,
            WeekStart = dto.WeekStart,
            WeekEnd = dto.WeekEnd,
            IsActive = dto.IsActive
        };
        await _menuService.Add(menu);
        return CreatedAtAction(nameof(GetById), new { id = menu.Id }, MapToDto(menu));
    }

    /// <summary>Get a weekly menu by id with its days.</summary>
    [HttpGet("{id:int}")]
    public async Task<ActionResult<WeeklyMenuDto>> GetById(int id)
    {
        var menu = await _menuService.GetById(id);
        if (menu == null) return NotFound();
        return Ok(MapToDto(menu));
    }

    /// <summary>Get all days for a weekly menu (Monday–Sunday with meals).</summary>
    [HttpGet("{id:int}/days")]
    public async Task<ActionResult<List<WeeklyMenuDayDto>>> GetDays(int id)
    {
        var days = await _dayService.GetByWeeklyMenuId(id);
        return Ok(days.Select(MapDayToDto).ToList());
    }

    /// <summary>Get menu for a specific day (e.g. Tuesday). dayOfWeek: 0=Sunday, 1=Monday, ..., 6=Saturday.</summary>
    [HttpGet("{id:int}/day/{dayOfWeek:int}")]
    public async Task<ActionResult<WeeklyMenuDayDto>> GetDay(int id, int dayOfWeek)
    {
        if (dayOfWeek < 0 || dayOfWeek > 6) return BadRequest("dayOfWeek must be 0-6 (Sunday=0, Monday=1, ..., Saturday=6).");
        var day = await _dayService.GetByWeeklyMenuAndDay(id, (DayOfWeek)dayOfWeek);
        if (day == null) return NotFound();
        return Ok(MapDayToDto(day));
    }

    /// <summary>Get the meal for a specific day and type (e.g. Tuesday breakfast). mealType: Breakfast, Lunch, Dinner, Snack.</summary>
    [HttpGet("{id:int}/day/{dayOfWeek:int}/meal/{mealType}")]
    public async Task<ActionResult<MealDto>> GetMealForDayAndType(int id, int dayOfWeek, string mealType)
    {
        if (dayOfWeek < 0 || dayOfWeek > 6) return BadRequest("dayOfWeek must be 0-6.");
        if (!Enum.TryParse<MealType>(mealType, ignoreCase: true, out var type))
            return BadRequest("mealType must be Breakfast, Lunch, Dinner, or Snack.");
        var meal = await _dayService.GetMealForDayAndType(id, (DayOfWeek)dayOfWeek, type);
        if (meal == null) return NotFound();
        return Ok(MapMealToDto(meal));
    }

    /// <summary>Set the meal for a day and type (e.g. set Tuesday breakfast to the given dish).</summary>
    [HttpPut("{id:int}/day/{dayOfWeek:int}/meal/{mealType}")]
    public async Task<ActionResult> SetMealForDayAndType(int id, int dayOfWeek, string mealType, [FromBody] SetMealRequestDto body)
    {
        if (dayOfWeek < 0 || dayOfWeek > 6) return BadRequest("dayOfWeek must be 0-6.");
        if (!Enum.TryParse<MealType>(mealType, ignoreCase: true, out var type))
            return BadRequest("mealType must be Breakfast, Lunch, Dinner, or Snack.");
        await _dayService.SetMealForDayAndType(id, (DayOfWeek)dayOfWeek, type, body.DishId);
        return NoContent();
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> Update(int id, [FromBody] WeeklyMenuUpdateDto dto)
    {
        var menu = await _menuService.GetById(id);
        if (menu == null) return NotFound();
        if (dto.Name != null) menu.Name = dto.Name;
        if (dto.WeekStart.HasValue) menu.WeekStart = dto.WeekStart.Value;
        if (dto.WeekEnd.HasValue) menu.WeekEnd = dto.WeekEnd.Value;
        if (dto.IsActive.HasValue) menu.IsActive = dto.IsActive.Value;
        await _menuService.Update(menu);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete(int id)
    {
        var menu = await _menuService.GetById(id);
        if (menu == null) return NotFound();
        await _menuService.Delete(id);
        return NoContent();
    }

    private static WeeklyMenuDto MapToDto(WeeklyMenu m)
    {
        return new WeeklyMenuDto
        {
            Id = m.Id,
            Name = m.Name,
            WeekStart = m.WeekStart,
            WeekEnd = m.WeekEnd,
            IsActive = m.IsActive,
            WeeklyMenuDays = m.WeeklyMenuDays?.Select(MapDayToDto).ToList()
        };
    }

    private static WeeklyMenuDayDto MapDayToDto(WeeklyMenuDay d)
    {
        return new WeeklyMenuDayDto
        {
            Id = d.Id,
            WeeklyMenuId = d.WeeklyMenuId,
            DayOfWeek = d.DayOfWeek,
            BreakfastDishId = d.BreakfastMeal?.DishId,
            LunchDishId = d.LunchMeal?.DishId,
            DinnerDishId = d.DinnerMeal?.DishId,
            SnackDishId = d.SnackMeal?.DishId,
            BreakfastDish = d.BreakfastMeal?.Dish != null ? MapDishToDto(d.BreakfastMeal.Dish) : null,
            LunchDish = d.LunchMeal?.Dish != null ? MapDishToDto(d.LunchMeal.Dish) : null,
            DinnerDish = d.DinnerMeal?.Dish != null ? MapDishToDto(d.DinnerMeal.Dish) : null,
            SnackDish = d.SnackMeal?.Dish != null ? MapDishToDto(d.SnackMeal.Dish) : null
        };
    }

    private static MealDto MapMealToDto(Meal m)
    {
        return new MealDto
        {
            Id = m.Id,
            MenuDayId = m.WeeklyMenuDayId,
            MealType = (MealTypeDto)m.MealType,
            DishId = m.DishId,
            Dish = m.Dish != null ? MapDishToDto(m.Dish) : null
        };
    }

    private static DishDto MapDishToDto(Dish d)
    {
        return new DishDto
        {
            Id = d.Id,
            Name = d.Name,
            CookTime = d.CookTime,
            Recipe = d.Recipe,
            CalculatedCalories = (decimal)d.CalculatedCalories,
            CalculatedProteins = (decimal)d.CalculatedProteins,
            CalculatedFats = (decimal)d.CalculatedFats,
            CalculatedCarbohydrates = (decimal)d.CalculatedCarbohydrates,
            DishIngredients = null
        };
    }
}
