namespace RecieptHub.BAL.Models;


public class WeeklyMenu
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public DateTime WeekStart { get; set; }
    public DateTime WeekEnd { get; set; }
    public bool IsActive { get; set; }

    public virtual ICollection<WeeklyMenuDay> WeeklyMenuDays { get; set; } = new List<WeeklyMenuDay>();
}
