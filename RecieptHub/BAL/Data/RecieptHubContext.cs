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
    public DbSet<NutritionTotal> NutritionTotals { get; set; }
    public DbSet<MenuDay> MenuDays { get; set; }
    public DbSet<Meal> Meals { get; set; }
    public DbSet<WeeklyMenu> WeeklyMenus { get; set; }
    public DbSet<WeeklyMenuDay> WeeklyMenuDays { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Dish <-> Ingredient via DishIngredient (many-to-many with quantity and line nutrition)
        modelBuilder.Entity<DishIngredient>()
            .HasOne(di => di.Dish)
            .WithMany(d => d.DishIngredients)
            .HasForeignKey(di => di.DishId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<DishIngredient>()
            .HasOne(di => di.Ingredient)
            .WithMany(i => i.DishIngredients)
            .HasForeignKey(di => di.IngredientId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<DishIngredient>()
            .HasIndex(di => new { di.DishId, di.IngredientId })
            .IsUnique();

        // NutritionTotal -> Dish (optional cache per dish)
        modelBuilder.Entity<NutritionTotal>()
            .HasOne(nt => nt.Dish)
            .WithMany()
            .HasForeignKey(nt => nt.DishId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<NutritionTotal>()
            .HasIndex(nt => nt.DishId)
            .IsUnique();

        // MenuDay -> Meals (one day, many meals: breakfast, lunch, dinner)
        modelBuilder.Entity<Meal>()
            .HasOne(m => m.MenuDay)
            .WithMany(md => md.Meals)
            .HasForeignKey(m => m.MenuDayId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Meal>()
            .HasOne(m => m.Dish)
            .WithMany()
            .HasForeignKey(m => m.DishId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Meal>()
            .HasIndex(m => new { m.MenuDayId, m.MealType })
            .IsUnique();

        // WeeklyMenu -> WeeklyMenuDays (one per weekday)
        modelBuilder.Entity<WeeklyMenuDay>()
            .HasOne(wmd => wmd.WeeklyMenu)
            .WithMany(wm => wm.WeeklyMenuDays)
            .HasForeignKey(wmd => wmd.WeeklyMenuId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<WeeklyMenuDay>()
            .HasOne(wmd => wmd.BreakfastDish)
            .WithMany()
            .HasForeignKey(wmd => wmd.BreakfastDishId)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<WeeklyMenuDay>()
            .HasOne(wmd => wmd.LunchDish)
            .WithMany()
            .HasForeignKey(wmd => wmd.LunchDishId)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<WeeklyMenuDay>()
            .HasOne(wmd => wmd.DinnerDish)
            .WithMany()
            .HasForeignKey(wmd => wmd.DinnerDishId)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<WeeklyMenuDay>()
            .HasOne(wmd => wmd.SnackDish)
            .WithMany()
            .HasForeignKey(wmd => wmd.SnackDishId)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<WeeklyMenuDay>()
            .HasIndex(wmd => new { wmd.WeeklyMenuId, wmd.DayOfWeek })
            .IsUnique();
    }
}
