using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace SweetGoods.Recipes.Infra.Data.Migrations
{
    public partial class InitialBaseSetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AggregateId = table.Column<Guid>(nullable: false),
                    CategoryType = table.Column<int>(nullable: false),
                    SoftDeleted = table.Column<bool>(nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AggregateId = table.Column<Guid>(nullable: false),
                    Details = table.Column<string>(type: "nvarchar(500)", nullable: true),
                    SoftDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AggregateId = table.Column<Guid>(nullable: false),
                    SoftDeleted = table.Column<bool>(nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CookingMethods",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AggregateId = table.Column<Guid>(nullable: false),
                    CookingTime = table.Column<TimeSpan>(type: "time(7)", nullable: false),
                    RecipeId = table.Column<int>(nullable: false),
                    SoftDeleted = table.Column<bool>(nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CookingMethods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CookingMethods_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecipeCategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AggregateId = table.Column<Guid>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false),
                    RecipeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecipeCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipeCategories_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CookingMethodIngredients",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AggregateId = table.Column<Guid>(nullable: false),
                    CookingMethodId = table.Column<int>(nullable: false),
                    IngredientId = table.Column<int>(nullable: false),
                    Measure = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MeasureType = table.Column<int>(type: "int", nullable: false),
                    Usage = table.Column<string>(type: "nvarchar(500)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CookingMethodIngredients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CookingMethodIngredients_CookingMethods_CookingMethodId",
                        column: x => x.CookingMethodId,
                        principalTable: "CookingMethods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CookingMethodIngredients_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CookingSteps",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AggregateId = table.Column<Guid>(nullable: false),
                    CookingMethodId = table.Column<int>(nullable: false),
                    StepAction = table.Column<string>(type: "nvarchar(500)", nullable: true),
                    StepNumber = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CookingSteps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CookingSteps_CookingMethods_CookingMethodId",
                        column: x => x.CookingMethodId,
                        principalTable: "CookingMethods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CookingMethodIngredients_CookingMethodId",
                table: "CookingMethodIngredients",
                column: "CookingMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_CookingMethodIngredients_IngredientId",
                table: "CookingMethodIngredients",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_CookingMethods_RecipeId",
                table: "CookingMethods",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_CookingSteps_CookingMethodId",
                table: "CookingSteps",
                column: "CookingMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeCategories_CategoryId",
                table: "RecipeCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeCategories_RecipeId",
                table: "RecipeCategories",
                column: "RecipeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CookingMethodIngredients");

            migrationBuilder.DropTable(
                name: "CookingSteps");

            migrationBuilder.DropTable(
                name: "RecipeCategories");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "CookingMethods");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Recipes");
        }
    }
}
