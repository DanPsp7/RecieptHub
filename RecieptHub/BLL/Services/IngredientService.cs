using RecieptHub.BAL.Interfaces;
using RecieptHub.BAL.Models;
using RecieptHub.BLL.Interfaces;

namespace RecieptHub.BLL.Services;

public class IngredientService : IIngredientService
{
    private readonly IIngredientRepository _repository;

    public IngredientService(IIngredientRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<Ingredient>> GetIngredients()
    {
        var ingredients = await _repository.GetIngredients();
        return ingredients;
    }
    
    public async Task AddIngredient(Ingredient ingredient)
    {
        await _repository.AddIngredient(ingredient);
    }

    public async Task UpdateIngredient(int id, Ingredient ingredient)
    {
        await _repository.UpdateIngredient(id, ingredient);
    }

    public async Task DeleteIngredient(int id)
    {
        await _repository.DeleteIngredient(id);
    }
}