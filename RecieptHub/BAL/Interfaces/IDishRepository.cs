using RecieptHub.BAL.Models;

namespace RecieptHub.BAL.Interfaces;

public interface IDishRepository
{
    Task<List<Dish>> GetDishes();
    
    Task<Dish> GetDishById(int id);
    
    Task AddDish(Dish dish);
    
    Task UpdateDish(int id, Dish dish);
    
    Task DeleteDish(int id);
}