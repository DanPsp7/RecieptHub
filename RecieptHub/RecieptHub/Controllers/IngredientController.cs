using Microsoft.AspNetCore.Mvc;
using RecieptHub.BAL.Models;
using RecieptHub.BLL.Interfaces;

namespace RecieptHub.RecieptHub.Controllers;

[ApiController]
[Route("[controller]")]
public class IngredientController : Controller
{
    
    private readonly IIngredientService _ingredientService;

    public IngredientController(IIngredientService ingredientService)
    {
        _ingredientService = ingredientService;
    }

    [HttpGet]
    public async Task<List<Ingredient>> GetIngredients()
    {
        return await _ingredientService.GetIngredients();
    }

    [HttpPost]
    public async Task AddIngredient(Ingredient ingredient)
    {
        await _ingredientService.AddIngredient(ingredient);
    }

    [HttpPut]
    public async Task UpdateIngredient(Ingredient ingredient)
    {
        await _ingredientService.UpdateIngredient(ingredient);
    }

    [HttpDelete]
    public async Task DeleteIngredient(int id)
    {
        await _ingredientService.DeleteIngredient(id);
    }
    
}