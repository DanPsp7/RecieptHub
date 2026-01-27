namespace RecieptHub.DTO;

public class WeeklyMenuDto
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public DateTime WeekStart { get; set; }
    public DateTime WeekEnd { get; set; }
    public bool IsActive { get; set; }
    public List<WeeklyMenuDayDto>? WeeklyMenuDays { get; set; }
}

public class WeeklyMenuCreateDto
{
    public required string Name { get; set; }
    public DateTime WeekStart { get; set; }
    public DateTime WeekEnd { get; set; }
    public bool IsActive { get; set; }
}

public class WeeklyMenuUpdateDto
{
    public string? Name { get; set; }
    public DateTime? WeekStart { get; set; }
    public DateTime? WeekEnd { get; set; }
    public bool? IsActive { get; set; }
}
