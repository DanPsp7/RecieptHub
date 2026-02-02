using System;
using RecieptHub.BAL.Interfaces;
using RecieptHub.BAL.Models;
using RecieptHub.BLL.Interfaces;

namespace RecieptHub.BLL.Services;

public class WeeklyMenuDayService : IWeeklyMenuDayService
{
    private readonly IWeeklyMenuDayRepository _repository;
    private readonly IMealRepository _mealRepository;

    public WeeklyMenuDayService(IWeeklyMenuDayRepository repository, IMealRepository mealRepository)
    {
        _repository = repository;
        _mealRepository = mealRepository;
    }

    public async Task<List<WeeklyMenuDay>> GetByWeeklyMenuId(int weeklyMenuId) =>
        await _repository.GetByWeeklyMenuId(weeklyMenuId);

    public async Task<WeeklyMenuDay?> GetById(int id) =>
        await _repository.GetById(id);

    public async Task<WeeklyMenuDay?> GetByWeeklyMenuAndDay(int weeklyMenuId, DayOfWeek dayOfWeek) =>
        await _repository.GetByWeeklyMenuAndDay(weeklyMenuId, dayOfWeek);

    public async Task<Meal?> GetMealForDayAndType(int weeklyMenuId, DayOfWeek dayOfWeek, MealType mealType)
    {
        var day = await _repository.GetByWeeklyMenuAndDay(weeklyMenuId, dayOfWeek);
        if (day == null) return null;
        return mealType switch
        {
            MealType.Breakfast => day.BreakfastMeal,
            MealType.Lunch => day.LunchMeal,
            MealType.Dinner => day.DinnerMeal,
            MealType.Snack => day.SnackMeal,
            _ => null
        };
    }

    public async Task SetMealForDayAndType(int weeklyMenuId, DayOfWeek dayOfWeek, MealType mealType, int dishId)
    {
        var day = await _repository.GetByWeeklyMenuAndDay(weeklyMenuId, dayOfWeek);
        if (day == null)
        {
            day = new WeeklyMenuDay { WeeklyMenuId = weeklyMenuId, DayOfWeek = dayOfWeek };
            await _repository.Add(day);
        }

        Meal? existingMeal = mealType switch
        {
            MealType.Breakfast => day.BreakfastMeal,
            MealType.Lunch => day.LunchMeal,
            MealType.Dinner => day.DinnerMeal,
            MealType.Snack => day.SnackMeal,
            _ => null
        };

        if (existingMeal != null)
        {
            existingMeal.DishId = dishId;
            await _mealRepository.Update(existingMeal);
        }
        else
        {
            var meal = new Meal
            {
                WeeklyMenuDayId = day.Id,
                MealType = mealType,
                DishId = dishId
            };
            await _mealRepository.Add(meal);
            switch (mealType)
            {
                case MealType.Breakfast: day.BreakfastMealId = meal.Id; break;
                case MealType.Lunch: day.LunchMealId = meal.Id; break;
                case MealType.Dinner: day.DinnerMealId = meal.Id; break;
                case MealType.Snack: day.SnackMealId = meal.Id; break;
            }
            await _repository.Update(day);
        }
    }

    public async Task Add(WeeklyMenuDay weeklyMenuDay) =>
        await _repository.Add(weeklyMenuDay);

    public async Task Update(WeeklyMenuDay weeklyMenuDay) =>
        await _repository.Update(weeklyMenuDay);

    public async Task Delete(int id) =>
        await _repository.Delete(id);
}
