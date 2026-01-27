using RecieptHub.BAL.Interfaces;
using RecieptHub.BAL.Models;
using RecieptHub.BLL.Interfaces;

namespace RecieptHub.BLL.Services;

public class NutritionTotalService : INutritionTotalService
{
    private readonly INutritionTotalRepository _repository;

    public NutritionTotalService(INutritionTotalRepository repository)
    {
        _repository = repository;
    }

    public async Task<NutritionTotal?> GetByDishId(int dishId) =>
        await _repository.GetByDishId(dishId);

    public async Task<NutritionTotal?> GetById(int id) =>
        await _repository.GetById(id);

    public async Task Add(NutritionTotal nutritionTotal) =>
        await _repository.Add(nutritionTotal);

    public async Task Update(NutritionTotal nutritionTotal) =>
        await _repository.Update(nutritionTotal);

    public async Task Delete(int id) =>
        await _repository.Delete(id);
}
