using RecieptHub.BAL.Models;

namespace RecieptHub.BAL.Interfaces;

public interface IIngredientRepository
{
    Task<List<Ingredient>> GetIngredients();
    
    Task AddIngredient(Ingredient ingredient);
    
    Task UpdateIngredient(int id ,Ingredient ingredient);
    
    Task DeleteIngredient(int id);
}