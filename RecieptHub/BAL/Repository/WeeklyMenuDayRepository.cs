using System;
using Microsoft.EntityFrameworkCore;
using RecieptHub.BAL.Data;
using RecieptHub.BAL.Interfaces;
using RecieptHub.BAL.Models;

namespace RecieptHub.BAL.Repository;

public class WeeklyMenuDayRepository : IWeeklyMenuDayRepository
{
    private readonly RecieptHubContext _context;

    public WeeklyMenuDayRepository(RecieptHubContext context)
    {
        _context = context;
    }

    public async Task<List<WeeklyMenuDay>> GetByWeeklyMenuId(int weeklyMenuId)
    {
        return await _context.WeeklyMenuDays
            .Include(wmd => wmd.BreakfastMeal!).ThenInclude(m => m.Dish)
            .Include(wmd => wmd.LunchMeal!).ThenInclude(m => m.Dish)
            .Include(wmd => wmd.DinnerMeal!).ThenInclude(m => m.Dish)
            .Include(wmd => wmd.SnackMeal!).ThenInclude(m => m.Dish)
            .Where(wmd => wmd.WeeklyMenuId == weeklyMenuId)
            .OrderBy(wmd => wmd.DayOfWeek)
            .ToListAsync();
    }

    public async Task<WeeklyMenuDay?> GetById(int id)
    {
        return await _context.WeeklyMenuDays
            .Include(wmd => wmd.BreakfastMeal!).ThenInclude(m => m.Dish)
            .Include(wmd => wmd.LunchMeal!).ThenInclude(m => m.Dish)
            .Include(wmd => wmd.DinnerMeal!).ThenInclude(m => m.Dish)
            .Include(wmd => wmd.SnackMeal!).ThenInclude(m => m.Dish)
            .FirstOrDefaultAsync(wmd => wmd.Id == id);
    }

    public async Task<WeeklyMenuDay?> GetByWeeklyMenuAndDay(int weeklyMenuId, DayOfWeek dayOfWeek)
    {
        return await _context.WeeklyMenuDays
            .Include(wmd => wmd.BreakfastMeal!).ThenInclude(m => m.Dish)
            .Include(wmd => wmd.LunchMeal!).ThenInclude(m => m.Dish)
            .Include(wmd => wmd.DinnerMeal!).ThenInclude(m => m.Dish)
            .Include(wmd => wmd.SnackMeal!).ThenInclude(m => m.Dish)
            .FirstOrDefaultAsync(wmd => wmd.WeeklyMenuId == weeklyMenuId && wmd.DayOfWeek == dayOfWeek);
    }

    public async Task Add(WeeklyMenuDay weeklyMenuDay)
    {
        await _context.WeeklyMenuDays.AddAsync(weeklyMenuDay);
        await _context.SaveChangesAsync();
    }

    public async Task Update(WeeklyMenuDay weeklyMenuDay)
    {
        var entry = await _context.WeeklyMenuDays.FindAsync(weeklyMenuDay.Id);
        if (entry == null) return;
        entry.DayOfWeek = weeklyMenuDay.DayOfWeek;
        entry.BreakfastMealId = weeklyMenuDay.BreakfastMealId;
        entry.LunchMealId = weeklyMenuDay.LunchMealId;
        entry.DinnerMealId = weeklyMenuDay.DinnerMealId;
        entry.SnackMealId = weeklyMenuDay.SnackMealId;
        await _context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var day = await _context.WeeklyMenuDays.FindAsync(id);
        if (day != null)
        {
            _context.WeeklyMenuDays.Remove(day);
            await _context.SaveChangesAsync();
        }
    }
}
