using RecieptHub.BAL.Models;

namespace RecieptHub.BAL.Interfaces;

public interface IMenuDayRepository
{
    Task<List<MenuDay>> GetAll();
    Task<MenuDay?> GetById(int id);
    Task<MenuDay?> GetByDate(DateTime date);
    Task Add(MenuDay menuDay);
    Task Update(MenuDay menuDay);
    Task Delete(int id);
}
