namespace RecieptHub.DTO;

/// <summary>Meal slot type (breakfast, lunch, dinner, snack). Mirrors BAL.Models.MealType for API contracts.</summary>
public enum MealTypeDto
{
    Breakfast = 0,
    Lunch = 1,
    Dinner = 2,
    Snack = 3
}
