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
            .OrderByDescending(wm => wm.WeekStart)
            .ToListAsync();
    }

    public async Task<WeeklyMenu?> GetById(int id)
    {
        return await _context.WeeklyMenus
            .Include(wm => wm.WeeklyMenuDays)
            .ThenInclude(wmd => wmd.BreakfastDish)
            .Include(wm => wm.WeeklyMenuDays)
            .ThenInclude(wmd => wmd.LunchDish)
            .Include(wm => wm.WeeklyMenuDays)
            .ThenInclude(wmd => wmd.DinnerDish)
            .Include(wm => wm.WeeklyMenuDays)
            .ThenInclude(wmd => wmd.SnackDish)
            .FirstOrDefaultAsync(wm => wm.Id == id);
    }

    public async Task<WeeklyMenu?> GetActive()
    {
        return await _context.WeeklyMenus
            .Include(wm => wm.WeeklyMenuDays)
            .ThenInclude(wmd => wmd.BreakfastDish)
            .Include(wm => wm.WeeklyMenuDays)
            .ThenInclude(wmd => wmd.LunchDish)
            .Include(wm => wm.WeeklyMenuDays)
            .ThenInclude(wmd => wmd.DinnerDish)
            .Include(wm => wm.WeeklyMenuDays)
            .ThenInclude(wmd => wmd.SnackDish)
            .FirstOrDefaultAsync(wm => wm.IsActive);
    }

    public async Task Add(WeeklyMenu weeklyMenu)
    {
        await _context.WeeklyMenus.AddAsync(weeklyMenu);
        await _context.SaveChangesAsync();
    }

    public async Task Update(WeeklyMenu weeklyMenu)
    {
        _context.WeeklyMenus.Update(weeklyMenu);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var entity = await _context.WeeklyMenus.FindAsync(id);
        if (entity == null)
            throw new KeyNotFoundException($"WeeklyMenu not found with id: {id}");
        _context.WeeklyMenus.Remove(entity);
        await _context.SaveChangesAsync();
    }
}
