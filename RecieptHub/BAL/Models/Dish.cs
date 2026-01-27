namespace RecieptHub.BAL.Models;

/// <summary>
/// A single dish (e.g. "Chicken with buckwheat"). Has many ingredients via DishIngredient
/// with quantity and per-line kcal; totals here are for the whole dish (sum of all ingredient lines).
/// </summary>
public class Dish
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public int CookTime { get; set; }
    public string? Recipe { get; set; }

    /// <summary>Total calories for the dish (sum of DishIngredient.CaloriesInDish).</summary>
    public decimal CalculatedCalories { get; set; }
    public decimal CalculatedProteins { get; set; }
    public decimal CalculatedFats { get; set; }
    public decimal CalculatedCarbohydrates { get; set; }

    public virtual ICollection<DishIngredient> DishIngredients { get; set; } = new List<DishIngredient>();
}
