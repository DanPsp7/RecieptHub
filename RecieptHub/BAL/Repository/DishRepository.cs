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

        return await _context.Dishes.FindAsync(id) ?? throw new ArgumentNullException($"Dish not found by id :{id}");
    }

    public async Task AddDish(Dish dish)
    {
        _context.Dishes.Add(dish);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateDish(int id, Dish dish)
    {
        var dishes = await _context.Dishes.FindAsync(id);
        if (dishes != null)
        {
            dish.Name = dishes.Name;
            dish.CookTime = dishes.CookTime;
            dish.Ingredients = dishes.Ingredients;
        }
        await _context.SaveChangesAsync();
        
    }

    public async Task DeleteDish(int id)
    {
        _context.Dishes.Remove(await _context.Dishes.FirstOrDefaultAsync(d => d.ID == id) ?? throw new Exception($"Dish not found id:{id}"));
        await _context.SaveChangesAsync();
        
    }
}