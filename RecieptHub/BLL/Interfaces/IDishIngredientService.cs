using RecieptHub.BAL.Models;

namespace RecieptHub.BLL.Interfaces;

public interface IDishIngredientService
{
    Task<List<DishIngredient>> GetByDishId(int dishId);
    Task<DishIngredient?> GetById(int id);
    Task Add(DishIngredient dishIngredient);
    Task Update(DishIngredient dishIngredient);
    Task Delete(int id);
}
