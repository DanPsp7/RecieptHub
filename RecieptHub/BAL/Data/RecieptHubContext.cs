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
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Dish>()
            .HasMany(d => d.Ingredients)
            .WithMany(i => i.Dishes);




    }
    
}