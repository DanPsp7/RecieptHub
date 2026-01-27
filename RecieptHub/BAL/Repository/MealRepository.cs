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

    public async Task<List<Meal>> GetByMenuDayId(int menuDayId)
    {
        return await _context.Meals
            .Include(m => m.Dish)
            .Where(m => m.MenuDayId == menuDayId)
            .OrderBy(m => m.MealType)
            .ToListAsync();
    }

    public async Task<Meal?> GetById(int id)
    {
        return await _context.Meals
            .Include(m => m.MenuDay)
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
        _context.Meals.Update(meal);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var entity = await _context.Meals.FindAsync(id);
        if (entity == null)
            throw new KeyNotFoundException($"Meal not found with id: {id}");
        _context.Meals.Remove(entity);
        await _context.SaveChangesAsync();
    }
}
