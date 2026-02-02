namespace RecieptHub.BAL.Models;


public class Meal
{
    public int Id { get; set; }
    public int WeeklyMenuDayId { get; set; }
    public MealType MealType { get; set; }
    public int DishId { get; set; }

    public virtual Dish Dish { get; set; } = null!;
    public virtual WeeklyMenuDay WeeklyMenuDay { get; set; } = null!;
}
public enum MealType
{
    Breakfast,
    Lunch,
    Dinner,
    Snack 
}