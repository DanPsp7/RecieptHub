namespace RecieptHub.BAL.Models;

/// <summary>
/// Links a dish to an ingredient with quantity. Nutrition values here are calculated
/// for this amount (e.g. quantity 200g of chicken = CaloriesInDish from ingredient per 100g × 2).
/// Ingredient stores nutrition per 100g; this entity stores quantity in grams and optionally
/// the calculated values for the dish line.
/// </summary>
public class DishIngredient
{
    public int Id { get; set; }
    public int DishId { get; set; }
    public int IngredientId { get; set; }

    /// <summary>Quantity in grams. Used with Ingredient's per-100g values to compute line totals.</summary>
    public decimal QuantityGrams { get; set; }

    /// <summary>Calories for this quantity (e.g. QuantityGrams/100 * Ingredient.Calories).</summary>
    public decimal CaloriesInDish { get; set; }
    public decimal ProteinsInDish { get; set; }
    public decimal FatsInDish { get; set; }
    public decimal CarbohydratesInDish { get; set; }

    public virtual Dish Dish { get; set; } = null!;
    public virtual Ingredient Ingredient { get; set; } = null!;
}
