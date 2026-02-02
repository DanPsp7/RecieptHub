namespace RecieptHub.BAL.Models;

public class Ingredient
{
    public int Id { get; set; }
    public required string Name { get; set; }

   
    public float Calories { get; set; }
    
    public float Proteins { get; set; }
    
    public float Fats { get; set; }
   
    public float Carbohydrates { get; set; }

    public virtual ICollection<DishIngredient> DishIngredients { get; set; } = new List<DishIngredient>();
}
