using System; // DayOfWeek

namespace RecieptHub.BAL.Models;

/// <summary>
/// One day in a weekly menu (e.g. Monday). Holds the dish for breakfast, lunch, and dinner.
/// Uses System.DayOfWeek (Sunday=0, Monday=1, ..., Saturday=6).
/// </summary>
public class WeeklyMenuDay
{
    public int Id { get; set; }
    public int WeeklyMenuId { get; set; }
    public DayOfWeek DayOfWeek { get; set; }

    public int? BreakfastDishId { get; set; }
    public int? LunchDishId { get; set; }
    public int? DinnerDishId { get; set; }
    public int? SnackDishId { get; set; }

    public virtual WeeklyMenu WeeklyMenu { get; set; } = null!;
    public virtual Dish? BreakfastDish { get; set; }
    public virtual Dish? LunchDish { get; set; }
    public virtual Dish? DinnerDish { get; set; }
    public virtual Dish? SnackDish { get; set; }
}
