using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace RecieptHub.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dishes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CookTime = table.Column<int>(type: "integer", nullable: false),
                    Recipe = table.Column<string>(type: "text", nullable: true),
                    CalculatedCalories = table.Column<float>(type: "real", nullable: false),
                    CalculatedProteins = table.Column<float>(type: "real", nullable: false),
                    CalculatedFats = table.Column<float>(type: "real", nullable: false),
                    CalculatedCarbohydrates = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dishes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Calories = table.Column<float>(type: "real", nullable: false),
                    Proteins = table.Column<float>(type: "real", nullable: false),
                    Fats = table.Column<float>(type: "real", nullable: false),
                    Carbohydrates = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WeeklyMenus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    WeekStart = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    WeekEnd = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeeklyMenus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DishIngredients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DishId = table.Column<int>(type: "integer", nullable: false),
                    IngredientId = table.Column<int>(type: "integer", nullable: false),
                    QuantityGrams = table.Column<float>(type: "real", nullable: false),
                    CaloriesInDish = table.Column<float>(type: "real", nullable: false),
                    ProteinsInDish = table.Column<float>(type: "real", nullable: false),
                    FatsInDish = table.Column<float>(type: "real", nullable: false),
                    CarbohydratesInDish = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DishIngredients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DishIngredients_Dishes_DishId",
                        column: x => x.DishId,
                        principalTable: "Dishes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DishIngredients_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Meals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    WeeklyMenuDayId = table.Column<int>(type: "integer", nullable: false),
                    MealType = table.Column<int>(type: "integer", nullable: false),
                    DishId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Meals_Dishes_DishId",
                        column: x => x.DishId,
                        principalTable: "Dishes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WeeklyMenuDays",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    WeeklyMenuId = table.Column<int>(type: "integer", nullable: false),
                    DayOfWeek = table.Column<int>(type: "integer", nullable: false),
                    BreakfastMealId = table.Column<int>(type: "integer", nullable: true),
                    LunchMealId = table.Column<int>(type: "integer", nullable: true),
                    DinnerMealId = table.Column<int>(type: "integer", nullable: true),
                    SnackMealId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeeklyMenuDays", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeeklyMenuDays_Meals_BreakfastMealId",
                        column: x => x.BreakfastMealId,
                        principalTable: "Meals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_WeeklyMenuDays_Meals_DinnerMealId",
                        column: x => x.DinnerMealId,
                        principalTable: "Meals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_WeeklyMenuDays_Meals_LunchMealId",
                        column: x => x.LunchMealId,
                        principalTable: "Meals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_WeeklyMenuDays_Meals_SnackMealId",
                        column: x => x.SnackMealId,
                        principalTable: "Meals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_WeeklyMenuDays_WeeklyMenus_WeeklyMenuId",
                        column: x => x.WeeklyMenuId,
                        principalTable: "WeeklyMenus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DishIngredients_DishId",
                table: "DishIngredients",
                column: "DishId");

            migrationBuilder.CreateIndex(
                name: "IX_DishIngredients_IngredientId",
                table: "DishIngredients",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_Meals_DishId",
                table: "Meals",
                column: "DishId");

            migrationBuilder.CreateIndex(
                name: "IX_Meals_WeeklyMenuDayId",
                table: "Meals",
                column: "WeeklyMenuDayId");

            migrationBuilder.CreateIndex(
                name: "IX_WeeklyMenuDays_BreakfastMealId",
                table: "WeeklyMenuDays",
                column: "BreakfastMealId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WeeklyMenuDays_DinnerMealId",
                table: "WeeklyMenuDays",
                column: "DinnerMealId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WeeklyMenuDays_LunchMealId",
                table: "WeeklyMenuDays",
                column: "LunchMealId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WeeklyMenuDays_SnackMealId",
                table: "WeeklyMenuDays",
                column: "SnackMealId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WeeklyMenuDays_WeeklyMenuId_DayOfWeek",
                table: "WeeklyMenuDays",
                columns: new[] { "WeeklyMenuId", "DayOfWeek" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Meals_WeeklyMenuDays_WeeklyMenuDayId",
                table: "Meals",
                column: "WeeklyMenuDayId",
                principalTable: "WeeklyMenuDays",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meals_Dishes_DishId",
                table: "Meals");

            migrationBuilder.DropForeignKey(
                name: "FK_Meals_WeeklyMenuDays_WeeklyMenuDayId",
                table: "Meals");

            migrationBuilder.DropTable(
                name: "DishIngredients");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "Dishes");

            migrationBuilder.DropTable(
                name: "WeeklyMenuDays");

            migrationBuilder.DropTable(
                name: "Meals");

            migrationBuilder.DropTable(
                name: "WeeklyMenus");
        }
    }
}
