using RecieptHub.BAL.Interfaces;
using RecieptHub.BAL.Models;
using RecieptHub.BLL.Interfaces;

namespace RecieptHub.BLL.Services;

public class MenuDayService : IMenuDayService
{
    private readonly IMenuDayRepository _repository;

    public MenuDayService(IMenuDayRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<MenuDay>> GetAll() =>
        await _repository.GetAll();

    public async Task<MenuDay?> GetById(int id) =>
        await _repository.GetById(id);

    public async Task<MenuDay?> GetByDate(DateTime date) =>
        await _repository.GetByDate(date);

    public async Task Add(MenuDay menuDay) =>
        await _repository.Add(menuDay);

    public async Task Update(MenuDay menuDay) =>
        await _repository.Update(menuDay);

    public async Task Delete(int id) =>
        await _repository.Delete(id);
}
