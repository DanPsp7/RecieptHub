namespace RecieptHub.DTO;

public class MenuDayDto
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public decimal DailyCalories { get; set; }
    public decimal DailyProteins { get; set; }
    public decimal DailyFats { get; set; }
    public decimal DailyCarbohydrates { get; set; }
    public List<MealDto>? Meals { get; set; }
}

public class MenuDayCreateDto
{
    public DateTime Date { get; set; }
}

public class MenuDayUpdateDto
{
    public DateTime? Date { get; set; }
    public decimal? DailyCalories { get; set; }
    public decimal? DailyProteins { get; set; }
    public decimal? DailyFats { get; set; }
    public decimal? DailyCarbohydrates { get; set; }
}
