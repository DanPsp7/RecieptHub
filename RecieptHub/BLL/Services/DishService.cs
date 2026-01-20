using RecieptHub.BAL.Interfaces;
using RecieptHub.BAL.Models;
using RecieptHub.BLL.Interfaces;

namespace RecieptHub.BLL.Services;

public class DishService : IDishService
{
    private readonly IDishRepository _dishRepository;

    public DishService(IDishRepository dishRepository)
    {
        _dishRepository = dishRepository;
    }

    public async Task<List<Dish>> GetDishes()
    {
        var dishes = await _dishRepository.GetDishes();
        return dishes;
    }

    public async Task<Dish> GetDishById(int id)
    {
        var dish = await _dishRepository.GetDishById(id);
        return dish;
    }
    public async Task AddDish(Dish dish)
    {
        await _dishRepository.AddDish(dish);
    }

    public async Task UpdateDish(Dish dish)
    {
        await _dishRepository.UpdateDish(dish);
    }

    public async Task DeleteDish(int id)
    {
        await _dishRepository.DeleteDish(id);
    }
}