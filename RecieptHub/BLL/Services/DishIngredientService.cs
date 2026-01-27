using RecieptHub.BAL.Interfaces;
using RecieptHub.BAL.Models;
using RecieptHub.BLL.Interfaces;

namespace RecieptHub.BLL.Services;

public class DishIngredientService : IDishIngredientService
{
    private readonly IDishIngredientRepository _repository;

    public DishIngredientService(IDishIngredientRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<DishIngredient>> GetByDishId(int dishId) =>
        await _repository.GetByDishId(dishId);

    public async Task<DishIngredient?> GetById(int id) =>
        await _repository.GetById(id);

    public async Task Add(DishIngredient dishIngredient) =>
        await _repository.Add(dishIngredient);

    public async Task Update(DishIngredient dishIngredient) =>
        await _repository.Update(dishIngredient);

    public async Task Delete(int id) =>
        await _repository.Delete(id);
}
