namespace RecieptHub.DTO;

public class DishDto
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public int CookTime { get; set; }
    public string? Recipe { get; set; }
    public decimal CalculatedCalories { get; set; }
    public decimal CalculatedProteins { get; set; }
    public decimal CalculatedFats { get; set; }
    public decimal CalculatedCarbohydrates { get; set; }
    public List<DishIngredientDto>? DishIngredients { get; set; }
}

public class DishCreateDto
{
    public required string Name { get; set; }
    public int CookTime { get; set; }
    public string? Recipe { get; set; }
}

public class DishUpdateDto
{
    public string? Name { get; set; }
    public int? CookTime { get; set; }
    public string? Recipe { get; set; }
}
