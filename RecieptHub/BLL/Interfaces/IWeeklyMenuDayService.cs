using System;
using RecieptHub.BAL.Models;

namespace RecieptHub.BLL.Interfaces;

public interface IWeeklyMenuDayService
{
    Task<List<WeeklyMenuDay>> GetByWeeklyMenuId(int weeklyMenuId);
    Task<WeeklyMenuDay?> GetById(int id);
    Task<WeeklyMenuDay?> GetByWeeklyMenuAndDay(int weeklyMenuId, DayOfWeek dayOfWeek);
    /// <summary>Get the meal (with dish) for a specific day and meal type, e.g. Tuesday breakfast.</summary>
    Task<Meal?> GetMealForDayAndType(int weeklyMenuId, DayOfWeek dayOfWeek, MealType mealType);
    /// <summary>Assign a dish to a day and meal slot, e.g. set Tuesday breakfast to the given dish.</summary>
    Task SetMealForDayAndType(int weeklyMenuId, DayOfWeek dayOfWeek, MealType mealType, int dishId);
    Task Add(WeeklyMenuDay weeklyMenuDay);
    Task Update(WeeklyMenuDay weeklyMenuDay);
    Task Delete(int id);
}
