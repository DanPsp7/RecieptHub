using System;
using RecieptHub.BAL.Models;

namespace RecieptHub.BAL.Interfaces;

public interface IWeeklyMenuDayRepository
{
    Task<List<WeeklyMenuDay>> GetByWeeklyMenuId(int weeklyMenuId);
    Task<WeeklyMenuDay?> GetById(int id);
    Task<WeeklyMenuDay?> GetByWeeklyMenuAndDay(int weeklyMenuId, DayOfWeek dayOfWeek);
    Task Add(WeeklyMenuDay weeklyMenuDay);
    Task Update(WeeklyMenuDay weeklyMenuDay);
    Task Delete(int id);
}
