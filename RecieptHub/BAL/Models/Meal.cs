namespace RecieptHub.BAL.Models;

/// <summary>
/// One meal slot in a daily menu (breakfast, lunch, or dinner). Each meal has exactly one dish.
/// </summary>
public class Meal
{
    public int Id { get; set; }
    public int MenuDayId { get; set; }
    public MealType MealType { get; set; }
    public int DishId { get; set; }

    public virtual MenuDay MenuDay { get; set; } = null!;
    public virtual Dish Dish { get; set; } = null!;
}
