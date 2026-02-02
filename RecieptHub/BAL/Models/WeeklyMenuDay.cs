using System; 

namespace RecieptHub.BAL.Models;


public class WeeklyMenuDay
{
    public int Id { get; set; }
    public int WeeklyMenuId { get; set; }
    public DayOfWeek DayOfWeek { get; set; }

    public int? BreakfastMealId { get; set; }
    public int? LunchMealId { get; set; }
    public int? DinnerMealId { get; set; }
    public int? SnackMealId { get; set; }

    public virtual WeeklyMenu WeeklyMenu { get; set; } = null!;
    public virtual Meal? BreakfastMeal { get; set; }
    public virtual Meal? LunchMeal { get; set; }
    public virtual Meal? DinnerMeal { get; set; }
    public virtual Meal? SnackMeal { get; set; }
}
