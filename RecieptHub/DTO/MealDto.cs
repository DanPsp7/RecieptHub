namespace RecieptHub.DTO;

public class MealDto
{
    public int Id { get; set; }
    public int MenuDayId { get; set; }
    public MealTypeDto MealType { get; set; }
    public int DishId { get; set; }
    public DishDto? Dish { get; set; }
}

public class MealCreateDto
{
    public int MenuDayId { get; set; }
    public MealTypeDto MealType { get; set; }
    public int DishId { get; set; }
}

public class MealUpdateDto
{
    public MealTypeDto? MealType { get; set; }
    public int? DishId { get; set; }
}
