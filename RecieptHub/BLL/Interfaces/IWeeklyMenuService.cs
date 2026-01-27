using RecieptHub.BAL.Models;

namespace RecieptHub.BLL.Interfaces;

public interface IWeeklyMenuService
{
    Task<List<WeeklyMenu>> GetAll();
    Task<WeeklyMenu?> GetById(int id);
    Task<WeeklyMenu?> GetActive();
    Task Add(WeeklyMenu weeklyMenu);
    Task Update(WeeklyMenu weeklyMenu);
    Task Delete(int id);
}
