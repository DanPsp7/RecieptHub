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

    public async Task AddIngredient(Ingredient ingredient)
    {
        await _context.Ingredients.AddAsync(ingredient);
    }

    public async Task UpdateIngredient(int id, Ingredient ingredient)
    {
        _context.Ingredients.Update(ingredient);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteIngredient(int id)
    {
        _context.Ingredients.Remove(await _context.Ingredients.FindAsync(id) ?? throw new KeyNotFoundException($"Ingredient not found whith id: {id}"));
        await _context.SaveChangesAsync();
    }
}