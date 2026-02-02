using RecieptHub.BAL.Interfaces;
using RecieptHub.BAL.Models;
using RecieptHub.BLL.Interfaces;

namespace RecieptHub.BLL.Services;

public class MealService : IMealService
{
    private readonly IMealRepository _repository;

    public MealService(IMealRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<Meal>> GetByWeeklyMenuDayId(int menuDayId) =>
        await _repository.GetByWeeklyMenuDayId(menuDayId);

    public async Task<Meal?> GetById(int id) =>
        await _repository.GetById(id);

    public async Task Add(Meal meal) =>
        await _repository.Add(meal);

    public async Task Update(Meal meal) =>
        await _repository.Update(meal);

    public async Task Delete(int id) =>
        await _repository.Delete(id);
}
