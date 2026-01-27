using RecieptHub.BAL.Models;

namespace RecieptHub.BLL.Interfaces;

public interface IMealService
{
    Task<List<Meal>> GetByMenuDayId(int menuDayId);
    Task<Meal?> GetById(int id);
    Task Add(Meal meal);
    Task Update(Meal meal);
    Task Delete(int id);
}
