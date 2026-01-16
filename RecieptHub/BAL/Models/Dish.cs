namespace RecieptHub.BAL.Models;

public class Dish
{
    public int ID { get; set; }
    
    public string Name { get; set; }
    
    public int CookTime { get; set; }
    
    public virtual ICollection<Ingredient> Ingredients { get; set; }
}