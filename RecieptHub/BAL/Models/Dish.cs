namespace RecieptHub.BAL.Models;


public class Dish
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public int CookTime { get; set; }
    public string? Recipe { get; set; }

  
    public float CalculatedCalories { get; set; }
    public float CalculatedProteins { get; set; }
    public float CalculatedFats { get; set; }
    public float CalculatedCarbohydrates { get; set; }

    public virtual ICollection<DishIngredient> DishIngredients { get; set; } = new List<DishIngredient>();
}
