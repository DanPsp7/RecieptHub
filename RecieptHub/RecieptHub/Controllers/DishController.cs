using Microsoft.AspNetCore.Mvc;
using RecieptHub.BAL.Data;
using RecieptHub.BAL.Models;
using RecieptHub.BLL.Interfaces;

namespace RecieptHub.RecieptHub.Controllers;

[ApiController]
[Route("[controller]")]
public class DishController : Controller
{
    private readonly IDishService _dishService;

    public DishController(IDishService dishService)
    {
        _dishService = dishService;
    }
    [HttpGet]
    public Task<List<Dish>> GetDishes()
    {
        return _dishService.GetDishes();
    }

    [HttpGet]
    public async Task<Dish> GetDishById(int id)
    {
        return await _dishService.GetDishById(id);
    }
    
    [HttpPost]
    public async Task AddDish(Dish dish)
    {
        await _dishService.AddDish(dish);
    }
    
    [HttpPut]
    public async Task UpdateDish(int id, Dish dish)
    {
        await _dishService.UpdateDish(id, dish);
    }

    [HttpDelete]
    public async Task DeleteDish(int id)
    {
        await _dishService.DeleteDish(id);
    }
}