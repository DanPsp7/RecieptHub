using RecieptHub.BAL.Models;

namespace RecieptHub.BAL.Interfaces;

public interface INutritionTotalRepository
{
    Task<NutritionTotal?> GetByDishId(int dishId);
    Task<NutritionTotal?> GetById(int id);
    Task Add(NutritionTotal nutritionTotal);
    Task Update(NutritionTotal nutritionTotal);
    Task Delete(int id);
}
