using Microsoft.EntityFrameworkCore;
using RecieptHub.BAL.Models;

namespace RecieptHub.BAL.Data;

public class RecieptHubContext : DbContext
{
    public RecieptHubContext(DbContextOptions<RecieptHubContext> options) : base(options)
    {
    }

    public DbSet<Dish> Dishes { get; set; }
    public DbSet<Ingredient> Ingredients { get; set; }
    public DbSet<DishIngredient> DishIngredients { get; set; }
    
    public DbSet<Meal> Meals { get; set; }
    public DbSet<WeeklyMenu> WeeklyMenus { get; set; }
    public DbSet<WeeklyMenuDay> WeeklyMenuDays { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Dish <-> Ingredient via DishIngredient (many-to-many with quantity and nutrition)
        

        // WeeklyMenu -> WeeklyMenuDays (one per weekday)
        

        // WeeklyMenuDay -> Meals (breakfast, lunch, dinner, snack slots); Meal belongs to one day
       

        // Meal -> Dish
        

        
    }
}
