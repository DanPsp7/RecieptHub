using RecieptHub.BAL.Models;

namespace RecieptHub.BLL.Interfaces;

public interface IIngredientService
{
    Task<List<Ingredient>> GetIngredients();
    Task<Ingredient?> GetById(int id);
    Task AddIngredient(Ingredient ingredient);
    Task UpdateIngredient(Ingredient ingredient);
    Task DeleteIngredient(int id);
}