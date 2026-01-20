namespace RecieptHub.BAL.Models;

public class Dish
{
    public int ID { get; set; }
    
    public required string Name { get; set; }
    
    public int CookTime { get; set; }
    
    public int KBJU { get; set; }
    
    public ICollection<Ingredient> Ingredients { get; set; } = new List<Ingredient>();

    
}