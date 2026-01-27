using Microsoft.EntityFrameworkCore;
using RecieptHub.BAL.Data;
using RecieptHub.BAL.Interfaces;
using RecieptHub.BAL.Models;

namespace RecieptHub.BAL.Repository;

public class DishIngredientRepository : IDishIngredientRepository
{
    private readonly RecieptHubContext _context;

    public DishIngredientRepository(RecieptHubContext context)
    {
        _context = context;
    }

    public async Task<List<DishIngredient>> GetByDishId(int dishId)
    {
        return await _context.DishIngredients
            .Include(di => di.Ingredient)
            .Where(di => di.DishId == dishId)
            .ToListAsync();
    }

    public async Task<DishIngredient?> GetById(int id)
    {
        return await _context.DishIngredients
            .Include(di => di.Dish)
            .Include(di => di.Ingredient)
            .FirstOrDefaultAsync(di => di.Id == id);
    }

    public async Task Add(DishIngredient dishIngredient)
    {
        await _context.DishIngredients.AddAsync(dishIngredient);
        await _context.SaveChangesAsync();
    }

    public async Task Update(DishIngredient dishIngredient)
    {
        _context.DishIngredients.Update(dishIngredient);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var entity = await _context.DishIngredients.FindAsync(id);
        if (entity == null)
            throw new KeyNotFoundException($"DishIngredient not found with id: {id}");
        _context.DishIngredients.Remove(entity);
        await _context.SaveChangesAsync();
    }
}
