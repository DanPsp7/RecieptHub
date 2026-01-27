using RecieptHub.BAL.Models;

namespace RecieptHub.BAL.Interfaces;

public interface IDishIngredientRepository
{
    Task<List<DishIngredient>> GetByDishId(int dishId);
    Task<DishIngredient?> GetById(int id);
    Task Add(DishIngredient dishIngredient);
    Task Update(DishIngredient dishIngredient);
    Task Delete(int id);
}
