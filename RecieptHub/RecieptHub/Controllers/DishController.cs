using Microsoft.AspNetCore.Mvc;
using RecieptHub.BAL.Models;
using RecieptHub.BLL.Interfaces;
using RecieptHub.DTO;

namespace RecieptHub.RecieptHub.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DishController : ControllerBase
{
    private readonly IDishService _dishService;

    public DishController(IDishService dishService)
    {
        _dishService = dishService;
    }

    [HttpGet]
    public async Task<List<Dish>> GetDishes()
    {
        return await _dishService.GetDishes();
    }

    [HttpGet("{id:int}")]
    public async Task <Dish> GetDishById(int id)
    {
        return await _dishService.GetDishById(id);
    }

    [HttpPost]
    public async Task Create([FromBody] DishCreateDto dish)
    {
        var newDish = new Dish()
        {
            Name = dish.Name,
            CookTime = dish.CookTime,
            Recipe = dish.Recipe
        };
        await _dishService.AddDish(newDish);
        
    }

    [HttpPut("{id:int}")]
    public async Task Update(int id, [FromBody] DishUpdateDto dish)
    {
        var oldDish = await _dishService.GetDishById(id);
        oldDish.Name = dish.Name;
        oldDish.CookTime = (int)dish.CookTime!;
        oldDish.Recipe = dish.Recipe;
        await _dishService.UpdateDish(oldDish);

    }

    [HttpDelete("{id:int}")]
    public async Task Delete(int id)
    {
        await _dishService.DeleteDish(id);
        
    }
}