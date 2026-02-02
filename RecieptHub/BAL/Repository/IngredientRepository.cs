using Microsoft.EntityFrameworkCore;
using RecieptHub.BAL.Data;
using RecieptHub.BAL.Interfaces;
using RecieptHub.BAL.Models;

namespace RecieptHub.BAL.Repository;

public class IngredientRepository : IIngredientRepository
{
    private readonly RecieptHubContext _context;

    public IngredientRepository(RecieptHubContext context)
    {
        _context = context;
    }

    public async Task<List<Ingredient>> GetIngredients()
    {
        return await _context.Ingredients.ToListAsync();
    }

    public async Task<Ingredient?> GetById(int id)
    {
        return await _context.Ingredients.FindAsync(id);
    }

    public async Task AddIngredient(Ingredient ingredient)
    {
        await _context.Ingredients.AddAsync(ingredient);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateIngredient(Ingredient ingredient)
    {
        var entry = await _context.Ingredients.FindAsync(ingredient.Id);
        if (entry == null) return;
        entry.Name = ingredient.Name;
        entry.Calories = ingredient.Calories;
        entry.Proteins = ingredient.Proteins;
        entry.Fats = ingredient.Fats;
        entry.Carbohydrates = ingredient.Carbohydrates;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteIngredient(int id)
    {
        var ingredient = await _context.Ingredients.FindAsync(id);
        if (ingredient != null)
        {
            _context.Ingredients.Remove(ingredient);
            await _context.SaveChangesAsync();
        }
    }
}