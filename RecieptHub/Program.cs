using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;
using Microsoft.OpenApi.Models;
using RecieptHub.BAL.Data;
using RecieptHub.BAL.Interfaces;
using RecieptHub.BAL.Repository;
using RecieptHub.BLL.Interfaces;
using RecieptHub.BLL.Services;


var builder = WebApplication.CreateBuilder(args);




builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<RecieptHubContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("RecieptHubDB") ?? throw new InvalidOperationException("Connection string 'RecieptHubDB' not found.")));

builder.Services.AddScoped<IDishRepository, DishRepository>();
builder.Services.AddScoped<IDishService, DishService>();

builder.Services.AddScoped<IIngredientRepository, IngredientRepository>();
builder.Services.AddScoped<IIngredientService, IngredientService>();

builder.Services.AddScoped<IDishIngredientRepository, DishIngredientRepository>();
builder.Services.AddScoped<IDishIngredientService, DishIngredientService>();

builder.Services.AddScoped<IMealRepository, MealRepository>();
builder.Services.AddScoped<IMealService, MealService>();

builder.Services.AddScoped<IWeeklyMenuRepository, WeeklyMenuRepository>();
builder.Services.AddScoped<IWeeklyMenuService, WeeklyMenuService>();

builder.Services.AddScoped<IWeeklyMenuDayRepository, WeeklyMenuDayRepository>();
builder.Services.AddScoped<IWeeklyMenuDayService, WeeklyMenuDayService>();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "My API",
        Version = "v1",
        Description = "API для управления данными",
        Contact = new OpenApiContact { Name = "Dev", Email = "dev@example.com" }
    });
});




var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => 
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    });
}

//app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();