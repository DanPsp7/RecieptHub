using Microsoft.EntityFrameworkCore;
using RecieptHub.BAL.Data;
using RecieptHub.BAL.Interfaces;
using RecieptHub.BAL.Models;

namespace RecieptHub.BAL.Repository;

public class NutritionTotalRepository : INutritionTotalRepository
{
    private readonly RecieptHubContext _context;

    public NutritionTotalRepository(RecieptHubContext context)
    {
        _context = context;
    }

    public async Task<NutritionTotal?> GetByDishId(int dishId)
    {
        return await _context.NutritionTotals
            .Include(nt => nt.Dish)
            .FirstOrDefaultAsync(nt => nt.DishId == dishId);
    }

    public async Task<NutritionTotal?> GetById(int id)
    {
        return await _context.NutritionTotals
            .Include(nt => nt.Dish)
            .FirstOrDefaultAsync(nt => nt.Id == id);
    }

    public async Task Add(NutritionTotal nutritionTotal)
    {
        await _context.NutritionTotals.AddAsync(nutritionTotal);
        await _context.SaveChangesAsync();
    }

    public async Task Update(NutritionTotal nutritionTotal)
    {
        _context.NutritionTotals.Update(nutritionTotal);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var entity = await _context.NutritionTotals.FindAsync(id);
        if (entity == null)
            throw new KeyNotFoundException($"NutritionTotal not found with id: {id}");
        _context.NutritionTotals.Remove(entity);
        await _context.SaveChangesAsync();
    }
}
