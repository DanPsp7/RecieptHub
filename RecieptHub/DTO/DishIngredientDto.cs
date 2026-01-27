namespace RecieptHub.DTO;

public class DishIngredientDto
{
    public int Id { get; set; }
    public int DishId { get; set; }
    public int IngredientId { get; set; }
    public string? IngredientName { get; set; }
    public decimal QuantityGrams { get; set; }
    public decimal CaloriesInDish { get; set; }
    public decimal ProteinsInDish { get; set; }
    public decimal FatsInDish { get; set; }
    public decimal CarbohydratesInDish { get; set; }
}

public class DishIngredientCreateDto
{
    public int DishId { get; set; }
    public int IngredientId { get; set; }
    public decimal QuantityGrams { get; set; }
}

public class DishIngredientUpdateDto
{
    public decimal QuantityGrams { get; set; }
}
