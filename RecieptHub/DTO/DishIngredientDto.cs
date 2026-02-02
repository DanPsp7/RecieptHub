namespace RecieptHub.DTO;

public class DishIngredientDto
{
    public int Id { get; set; }
    public int DishId { get; set; }
    public int IngredientId { get; set; }
    public string? IngredientName { get; set; }
    public float QuantityGrams { get; set; }
    public float CaloriesInDish { get; set; }
    public float ProteinsInDish { get; set; }
    public float FatsInDish { get; set; }
    public float CarbohydratesInDish { get; set; }
}

public class DishIngredientCreateDto
{
    public int DishId { get; set; }
    public int IngredientId { get; set; }
    public float QuantityGrams { get; set; }
}

public class DishIngredientUpdateDto
{
    public float QuantityGrams { get; set; }
}
