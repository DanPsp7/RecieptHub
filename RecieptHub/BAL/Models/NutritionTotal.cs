namespace RecieptHub.BAL.Models;

/// <summary>
/// Optional cache of dish totals and total weight (e.g. total recipe weight in grams).
/// Dish.Calculated* holds the same totals; this entity can store TotalWeight or per-serving data if needed.
/// </summary>
public class NutritionTotal
{
    public int Id { get; set; }
    public int DishId { get; set; }

    public decimal TotalCalories { get; set; }
    public decimal TotalProteins { get; set; }
    public decimal TotalFats { get; set; }
    public decimal TotalCarbohydrates { get; set; }
    /// <summary>Total recipe weight in grams (sum of DishIngredient.QuantityGrams for the dish).</summary>
    public decimal TotalWeight { get; set; }

    public virtual Dish Dish { get; set; } = null!;
}
