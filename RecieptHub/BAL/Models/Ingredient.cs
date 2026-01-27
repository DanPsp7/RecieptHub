namespace RecieptHub.BAL.Models;

/// <summary>
/// Ingredient catalog. Nutrition values are per 100g (standard for recipes).
/// Use DishIngredient to link to dishes with a specific quantity and calculated kcal per line.
/// </summary>
public class Ingredient
{
    public int Id { get; set; }
    public required string Name { get; set; }

    /// <summary>Calories per 100g (kcal).</summary>
    public decimal Calories { get; set; }
    /// <summary>Proteins per 100g (g).</summary>
    public decimal Proteins { get; set; }
    /// <summary>Fats per 100g (g).</summary>
    public decimal Fats { get; set; }
    /// <summary>Carbohydrates per 100g (g).</summary>
    public decimal Carbohydrates { get; set; }

    public virtual ICollection<DishIngredient> DishIngredients { get; set; } = new List<DishIngredient>();
}
