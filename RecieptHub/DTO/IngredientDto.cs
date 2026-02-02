namespace RecieptHub.DTO;

public class IngredientDto
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public decimal Calories { get; set; }
    public decimal Proteins { get; set; }
    public decimal Fats { get; set; }
    public decimal Carbohydrates { get; set; }
}

public class IngredientCreateDto
{
    public required string Name { get; set; }
    public float Calories { get; set; }
    public float Proteins { get; set; }
    public float Fats { get; set; }
    public float Carbohydrates { get; set; }
}

public class IngredientUpdateDto
{
    public string? Name { get; set; }
    public decimal? Calories { get; set; }
    public decimal? Proteins { get; set; }
    public decimal? Fats { get; set; }
    public decimal? Carbohydrates { get; set; }
}
