using RecieptHub.BAL.Models;

namespace RecieptHub.BAL.Interfaces;

public interface IWeeklyMenuRepository
{
    Task<List<WeeklyMenu>> GetAll();
    Task<WeeklyMenu?> GetById(int id);
    Task<WeeklyMenu?> GetActive();
    Task Add(WeeklyMenu weeklyMenu);
    Task Update(WeeklyMenu weeklyMenu);
    Task Delete(int id);
}
