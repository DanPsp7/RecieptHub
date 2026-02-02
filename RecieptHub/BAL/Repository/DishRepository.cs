using Microsoft.EntityFrameworkCore;
using RecieptHub.BAL.Data;
using RecieptHub.BAL.Interfaces;
using RecieptHub.BAL.Models;

namespace RecieptHub.BAL.Repository;

public class DishRepository : IDishRepository
{
    private readonly RecieptHubContext _context;

    public DishRepository(RecieptHubContext context)
    {
        _context = context;
    }

    public async Task<List<Dish>> GetDishes()
    {
        return await _context.Dishes.ToListAsync();
    }

    public async Task<Dish> GetDishById(int id)
    {
        return await _context.Dishes
            .Include(d => d.DishIngredients)
            .FirstOrDefaultAsync(d => d.Id == id) ?? throw new InvalidOperationException();
    }

    public async Task AddDish(Dish dish)
    {
        await _context.Dishes.AddAsync(dish);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateDish(Dish dish)
    {
        var entry = await _context.Dishes.FindAsync(dish.Id);
        if (entry == null) throw new InvalidOperationException("Dish not found.");
        entry.Name = dish.Name;
        entry.CookTime = dish.CookTime;
        entry.Recipe = dish.Recipe;
        entry.CalculatedCalories = dish.CalculatedCalories;
        entry.CalculatedProteins = dish.CalculatedProteins;
        entry.CalculatedFats = dish.CalculatedFats;
        entry.CalculatedCarbohydrates = dish.CalculatedCarbohydrates;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteDish(int id)
    {
        var dish = await _context.Dishes.FindAsync(id);
        if (dish != null)
        {
            _context.Dishes.Remove(dish);
            await _context.SaveChangesAsync();
        }
    }
}