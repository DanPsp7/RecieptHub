using Microsoft.EntityFrameworkCore;
using RecieptHub.BAL.Data;
using RecieptHub.BAL.Interfaces;
using RecieptHub.BAL.Models;

namespace RecieptHub.BAL.Repository;

public class MealRepository : IMealRepository
{
    private readonly RecieptHubContext _context;

    public MealRepository(RecieptHubContext context)
    {
        _context = context;
    }

    public async Task<List<Meal>> GetByWeeklyMenuDayId(int menuDayId)
    {
        var day = await _context.WeeklyMenuDays
            .Include(wmd => wmd.BreakfastMeal!).ThenInclude(m => m.Dish)
            .Include(wmd => wmd.LunchMeal!).ThenInclude(m => m.Dish)
            .Include(wmd => wmd.DinnerMeal!).ThenInclude(m => m.Dish)
            .Include(wmd => wmd.SnackMeal!).ThenInclude(m => m.Dish)
            .FirstOrDefaultAsync(wmd => wmd.Id == menuDayId);
        if (day == null) return new List<Meal>();
        var list = new List<Meal>();
        if (day.BreakfastMeal != null) list.Add(day.BreakfastMeal);
        if (day.LunchMeal != null) list.Add(day.LunchMeal);
        if (day.DinnerMeal != null) list.Add(day.DinnerMeal);
        if (day.SnackMeal != null) list.Add(day.SnackMeal);
        return list;
    }

    public async Task<Meal?> GetById(int id)
    {
        return await _context.Meals
            .Include(m => m.Dish)
            .FirstOrDefaultAsync(m => m.Id == id);
    }

    public async Task Add(Meal meal)
    {
        await _context.Meals.AddAsync(meal);
        await _context.SaveChangesAsync();
    }

    public async Task Update(Meal meal)
    {
        var entry = await _context.Meals.FindAsync(meal.Id);
        if (entry == null) return;
        entry.MealType = meal.MealType;
        entry.DishId = meal.DishId;
        await _context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var meal = await _context.Meals.FindAsync(id);
        if (meal != null)
        {
            _context.Meals.Remove(meal);
            await _context.SaveChangesAsync();
        }
    }
}
