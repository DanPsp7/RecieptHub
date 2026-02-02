using Microsoft.EntityFrameworkCore;
using RecieptHub.BAL.Data;
using RecieptHub.BAL.Interfaces;
using RecieptHub.BAL.Models;

namespace RecieptHub.BAL.Repository;

public class WeeklyMenuRepository : IWeeklyMenuRepository
{
    private readonly RecieptHubContext _context;

    public WeeklyMenuRepository(RecieptHubContext context)
    {
        _context = context;
    }

    public async Task<List<WeeklyMenu>> GetAll()
    {
        return await _context.WeeklyMenus
            .Include(wm => wm.WeeklyMenuDays)
                .ThenInclude(wmd => wmd.BreakfastMeal!).ThenInclude(m => m.Dish)
            .Include(wm => wm.WeeklyMenuDays)
                .ThenInclude(wmd => wmd.LunchMeal!).ThenInclude(m => m.Dish)
            .Include(wm => wm.WeeklyMenuDays)
                .ThenInclude(wmd => wmd.DinnerMeal!).ThenInclude(m => m.Dish)
            .Include(wm => wm.WeeklyMenuDays)
                .ThenInclude(wmd => wmd.SnackMeal!).ThenInclude(m => m.Dish)
            .OrderByDescending(wm => wm.WeekStart)
            .ToListAsync();
    }

    public async Task<WeeklyMenu?> GetById(int id)
    {
        return await _context.WeeklyMenus
            .Include(wm => wm.WeeklyMenuDays)
                .ThenInclude(wmd => wmd.BreakfastMeal!).ThenInclude(m => m.Dish)
            .Include(wm => wm.WeeklyMenuDays)
                .ThenInclude(wmd => wmd.LunchMeal!).ThenInclude(m => m.Dish)
            .Include(wm => wm.WeeklyMenuDays)
                .ThenInclude(wmd => wmd.DinnerMeal!).ThenInclude(m => m.Dish)
            .Include(wm => wm.WeeklyMenuDays)
                .ThenInclude(wmd => wmd.SnackMeal!).ThenInclude(m => m.Dish)
            .FirstOrDefaultAsync(wm => wm.Id == id);
    }

    public async Task<WeeklyMenu?> GetActive()
    {
        return await _context.WeeklyMenus
            .Include(wm => wm.WeeklyMenuDays)
                .ThenInclude(wmd => wmd.BreakfastMeal!).ThenInclude(m => m.Dish)
            .Include(wm => wm.WeeklyMenuDays)
                .ThenInclude(wmd => wmd.LunchMeal!).ThenInclude(m => m.Dish)
            .Include(wm => wm.WeeklyMenuDays)
                .ThenInclude(wmd => wmd.DinnerMeal!).ThenInclude(m => m.Dish)
            .Include(wm => wm.WeeklyMenuDays)
                .ThenInclude(wmd => wmd.SnackMeal!).ThenInclude(m => m.Dish)
            .FirstOrDefaultAsync(wm => wm.IsActive);
    }

    public async Task Add(WeeklyMenu weeklyMenu)
    {
        await _context.WeeklyMenus.AddAsync(weeklyMenu);
        await _context.SaveChangesAsync();
    }

    public async Task Update(WeeklyMenu weeklyMenu)
    {
        var entry = await _context.WeeklyMenus.FindAsync(weeklyMenu.Id);
        if (entry == null) return;
        entry.Name = weeklyMenu.Name;
        entry.WeekStart = weeklyMenu.WeekStart;
        entry.WeekEnd = weeklyMenu.WeekEnd;
        entry.IsActive = weeklyMenu.IsActive;
        await _context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var menu = await _context.WeeklyMenus.FindAsync(id);
        if (menu != null)
        {
            _context.WeeklyMenus.Remove(menu);
            await _context.SaveChangesAsync();
        }
    }
}
