namespace RecieptHub.BAL.Models;

/// <summary>
/// One calendar day's menu. Contains meals (breakfast, lunch, dinner) for that date.
/// Daily totals can be computed from the sum of all meals' dish nutrition, or stored here for caching.
/// </summary>
public class MenuDay
{
    public int Id { get; set; }
    public DateTime Date { get; set; }

    /// <summary>Optional cached totals for the day (sum of all meals' dish nutrition).</summary>
    public decimal DailyCalories { get; set; }
    public decimal DailyProteins { get; set; }
    public decimal DailyFats { get; set; }
    public decimal DailyCarbohydrates { get; set; }

    public virtual ICollection<Meal> Meals { get; set; } = new List<Meal>();
}
