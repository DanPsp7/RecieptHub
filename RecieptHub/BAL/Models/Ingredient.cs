namespace RecieptHub.BAL.Models;

public class Ingredient
{
    public int IngredientID { get; set; }
    
    public string IngredientName { get; set; }
    
    public int KBJU_one { get; set; }
    
    public ICollection<Dish> Dishes { get; set; } = new List<Dish>();

    
}