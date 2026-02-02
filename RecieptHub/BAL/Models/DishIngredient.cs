namespace RecieptHub.BAL.Models;


public class DishIngredient
{
    public int Id { get; set; }
    public int DishId { get; set; }
    public int IngredientId { get; set; }
    
    public float QuantityGrams { get; set; }
    
    public float CaloriesInDish { get; set; }
    public float ProteinsInDish { get; set; }
    public float FatsInDish { get; set; }
    public float CarbohydratesInDish { get; set; }

    public virtual Dish Dish { get; set; } = null!;
    public virtual Ingredient Ingredient { get; set; } = null!;
}
