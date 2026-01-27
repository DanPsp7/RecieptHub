using System;

namespace RecieptHub.DTO;

public class WeeklyMenuDayDto
{
    public int Id { get; set; }
    public int WeeklyMenuId { get; set; }
    public DayOfWeek DayOfWeek { get; set; }
    public int? BreakfastDishId { get; set; }
    public int? LunchDishId { get; set; }
    public int? DinnerDishId { get; set; }
    public int? SnackDishId { get; set; }
    public DishDto? BreakfastDish { get; set; }
    public DishDto? LunchDish { get; set; }
    public DishDto? DinnerDish { get; set; }
    public DishDto? SnackDish { get; set; }
}

public class WeeklyMenuDayCreateDto
{
    public int WeeklyMenuId { get; set; }
    public DayOfWeek DayOfWeek { get; set; }
    public int? BreakfastDishId { get; set; }
    public int? LunchDishId { get; set; }
    public int? DinnerDishId { get; set; }
    public int? SnackDishId { get; set; }
}

public class WeeklyMenuDayUpdateDto
{
    public int? BreakfastDishId { get; set; }
    public int? LunchDishId { get; set; }
    public int? DinnerDishId { get; set; }
    public int? SnackDishId { get; set; }
}
