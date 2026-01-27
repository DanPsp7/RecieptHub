using Microsoft.EntityFrameworkCore;
using RecieptHub.BAL.Data;
using RecieptHub.BAL.Interfaces;
using RecieptHub.BAL.Models;

namespace RecieptHub.BAL.Repository;

public class MenuDayRepository : IMenuDayRepository
{
    private readonly RecieptHubContext _context;

    public MenuDayRepository(RecieptHubContext context)
    {
        _context = context;
    }

    public async Task<List<MenuDay>> GetAll()
    {
        return await _context.MenuDays
            .Include(md => md.Meals)
            .ThenInclude(m => m.Dish)
            .OrderBy(md => md.Date)
            .ToListAsync();
    }

    public async Task<MenuDay?> GetById(int id)
    {
        return await _context.MenuDays
            .Include(md => md.Meals)
            .ThenInclude(m => m.Dish)
            .FirstOrDefaultAsync(md => md.Id == id);
    }

    public async Task<MenuDay?> GetByDate(DateTime date)
    {
        var dateOnly = date.Date;
        return await _context.MenuDays
            .Include(md => md.Meals)
            .ThenInclude(m => m.Dish)
            .FirstOrDefaultAsync(md => md.Date.Date == dateOnly);
    }

    public async Task Add(MenuDay menuDay)
    {
        await _context.MenuDays.AddAsync(menuDay);
        await _context.SaveChangesAsync();
    }

    public async Task Update(MenuDay menuDay)
    {
        _context.MenuDays.Update(menuDay);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var entity = await _context.MenuDays.FindAsync(id);
        if (entity == null)
            throw new KeyNotFoundException($"MenuDay not found with id: {id}");
        _context.MenuDays.Remove(entity);
        await _context.SaveChangesAsync();
    }
}
