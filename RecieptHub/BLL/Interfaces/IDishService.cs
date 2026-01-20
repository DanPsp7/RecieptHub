using RecieptHub.BAL.Models;

namespace RecieptHub.BLL.Interfaces;

public interface IDishService
{
    Task<List<Dish>> GetDishes();
    
    Task <Dish> GetDishById(int id);
    
    Task AddDish(Dish dish);
    
    Task UpdateDish(Dish dish);
    
    Task DeleteDish(int id);
}