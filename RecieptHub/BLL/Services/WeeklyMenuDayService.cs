using System;
using RecieptHub.BAL.Interfaces;
using RecieptHub.BAL.Models;
using RecieptHub.BLL.Interfaces;

namespace RecieptHub.BLL.Services;

public class WeeklyMenuDayService : IWeeklyMenuDayService
{
    private readonly IWeeklyMenuDayRepository _repository;

    public WeeklyMenuDayService(IWeeklyMenuDayRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<WeeklyMenuDay>> GetByWeeklyMenuId(int weeklyMenuId) =>
        await _repository.GetByWeeklyMenuId(weeklyMenuId);

    public async Task<WeeklyMenuDay?> GetById(int id) =>
        await _repository.GetById(id);

    public async Task<WeeklyMenuDay?> GetByWeeklyMenuAndDay(int weeklyMenuId, DayOfWeek dayOfWeek) =>
        await _repository.GetByWeeklyMenuAndDay(weeklyMenuId, dayOfWeek);

    public async Task Add(WeeklyMenuDay weeklyMenuDay) =>
        await _repository.Add(weeklyMenuDay);

    public async Task Update(WeeklyMenuDay weeklyMenuDay) =>
        await _repository.Update(weeklyMenuDay);

    public async Task Delete(int id) =>
        await _repository.Delete(id);
}
