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
            .Include(wmd => wmd.BreakfastDish)
            .Include(wmd => wmd.LunchDish)
            .Include(wmd => wmd.DinnerDish)
            .Include(wmd => wmd.SnackDish)
            .Where(wmd => wmd.WeeklyMenuId == weeklyMenuId)
            .OrderBy(wmd => wmd.DayOfWeek)
            .ToListAsync();
    }

    public async Task<WeeklyMenuDay?> GetById(int id)
    {
        return await _context.WeeklyMenuDays
            .Include(wmd => wmd.WeeklyMenu)
            .Include(wmd => wmd.BreakfastDish)
            .Include(wmd => wmd.LunchDish)
            .Include(wmd => wmd.DinnerDish)
            .Include(wmd => wmd.SnackDish)
            .FirstOrDefaultAsync(wmd => wmd.Id == id);
    }

    public async Task<WeeklyMenuDay?> GetByWeeklyMenuAndDay(int weeklyMenuId, DayOfWeek dayOfWeek)
    {
        return await _context.WeeklyMenuDays
            .Include(wmd => wmd.BreakfastDish)
            .Include(wmd => wmd.LunchDish)
            .Include(wmd => wmd.DinnerDish)
            .Include(wmd => wmd.SnackDish)
            .FirstOrDefaultAsync(wmd => wmd.WeeklyMenuId == weeklyMenuId && wmd.DayOfWeek == dayOfWeek);
    }

    public async Task Add(WeeklyMenuDay weeklyMenuDay)
    {
        await _context.WeeklyMenuDays.AddAsync(weeklyMenuDay);
        await _context.SaveChangesAsync();
    }

    public async Task Update(WeeklyMenuDay weeklyMenuDay)
    {
        _context.WeeklyMenuDays.Update(weeklyMenuDay);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var entity = await _context.WeeklyMenuDays.FindAsync(id);
        if (entity == null)
            throw new KeyNotFoundException($"WeeklyMenuDay not found with id: {id}");
        _context.WeeklyMenuDays.Remove(entity);
        await _context.SaveChangesAsync();
    }
}
