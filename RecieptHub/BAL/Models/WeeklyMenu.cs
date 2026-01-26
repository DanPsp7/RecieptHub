namespace RecieptHub.BAL.Models;

public class WeeklyMenu
{
    public int WeeklyMenuID { get; set; }
    public int MenuID { get; set; }
    
    public DayOfWeek DayOfWeek { get; set; }
}