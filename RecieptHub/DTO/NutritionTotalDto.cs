namespace RecieptHub.DTO;

public class NutritionTotalDto
{
    public int Id { get; set; }
    public int DishId { get; set; }
    public decimal TotalCalories { get; set; }
    public decimal TotalProteins { get; set; }
    public decimal TotalFats { get; set; }
    public decimal TotalCarbohydrates { get; set; }
    public decimal TotalWeight { get; set; }
}

public class NutritionTotalCreateDto
{
    public int DishId { get; set; }
    public decimal TotalCalories { get; set; }
    public decimal TotalProteins { get; set; }
    public decimal TotalFats { get; set; }
    public decimal TotalCarbohydrates { get; set; }
    public decimal TotalWeight { get; set; }
}

public class NutritionTotalUpdateDto
{
    public decimal? TotalCalories { get; set; }
    public decimal? TotalProteins { get; set; }
    public decimal? TotalFats { get; set; }
    public decimal? TotalCarbohydrates { get; set; }
    public decimal? TotalWeight { get; set; }
}
