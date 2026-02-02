using System;
using RecieptHub.BAL.Interfaces;
using RecieptHub.BAL.Models;
using RecieptHub.BLL.Interfaces;

namespace RecieptHub.BLL.Services;

public class WeeklyMenuService : IWeeklyMenuService
{
    private readonly IWeeklyMenuRepository _repository;
    private readonly IWeeklyMenuDayRepository _dayRepository;

    public WeeklyMenuService(IWeeklyMenuRepository repository, IWeeklyMenuDayRepository dayRepository)
    {
        _repository = repository;
        _dayRepository = dayRepository;
    }

    public async Task<List<WeeklyMenu>> GetAll() =>
        await _repository.GetAll();

    public async Task<WeeklyMenu?> GetById(int id) =>
        await _repository.GetById(id);

    public async Task<WeeklyMenu?> GetActive() =>
        await _repository.GetActive();

    public async Task Add(WeeklyMenu weeklyMenu)
    {
        await _repository.Add(weeklyMenu);
        for (var d = DayOfWeek.Monday; d <= DayOfWeek.Sunday; d++)
        {
            await _dayRepository.Add(new WeeklyMenuDay { WeeklyMenuId = weeklyMenu.Id, DayOfWeek = d });
        }
    }

    public async Task Update(WeeklyMenu weeklyMenu) =>
        await _repository.Update(weeklyMenu);

    public async Task Delete(int id) =>
        await _repository.Delete(id);
}
