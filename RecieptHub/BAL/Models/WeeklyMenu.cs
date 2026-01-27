namespace RecieptHub.BAL.Models;

/// <summary>
/// A weekly menu template. Has one entry per day of the week (WeeklyMenuDay)
/// with breakfast, lunch, and dinner dishes for each day.
/// </summary>
public class WeeklyMenu
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public DateTime WeekStart { get; set; }
    public DateTime WeekEnd { get; set; }
    public bool IsActive { get; set; }

    public virtual ICollection<WeeklyMenuDay> WeeklyMenuDays { get; set; } = new List<WeeklyMenuDay>();
}
