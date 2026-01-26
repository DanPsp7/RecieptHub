namespace RecieptHub.BAL.Models;

public class Menu
{
    public int MenuID { get; set; }
    
    public virtual ICollection<Dish> Dishes { get; set; } = new List<Dish>();
}