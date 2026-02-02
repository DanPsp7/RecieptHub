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
           .Where(d => d.DishId == dishId)
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
        var entry = await _context.DishIngredients.FindAsync(dishIngredient.Id);
        if (entry == null) return;
        entry.QuantityGrams = dishIngredient.QuantityGrams;
        entry.CaloriesInDish = dishIngredient.CaloriesInDish;
        entry.ProteinsInDish = dishIngredient.ProteinsInDish;
        entry.FatsInDish = dishIngredient.FatsInDish;
        entry.CarbohydratesInDish = dishIngredient.CarbohydratesInDish;
        await _context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var di = await _context.DishIngredients.FindAsync(id);
        if (di != null)
        {
            _context.DishIngredients.Remove(di);
            await _context.SaveChangesAsync();
        }
    }
}
