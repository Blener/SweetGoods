using Microsoft.EntityFrameworkCore;
using SweetGoods.Recipes.Domain.Models.Entities;
using SweetGoods.Recipes.Infra.Data.Extensions;
using SweetGoods.Recipes.Infra.Data.Mappings;

namespace SweetGoods.Recipes.Infra.Data.Context
{
    public class SweetGoodsRecipesContext : ContextBase<SweetGoodsRecipesContext>
    {
        public SweetGoodsRecipesContext(DbContextOptions<SweetGoodsRecipesContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddConfiguration(new CategoryMap());
            modelBuilder.AddConfiguration(new CookingMethodMap());
            modelBuilder.AddConfiguration(new CookingMethodIngredientMap());
            modelBuilder.AddConfiguration(new CookingStepsMap());
            modelBuilder.AddConfiguration(new IngredientMap());
            modelBuilder.AddConfiguration(new RecipeCategoryMap());
            modelBuilder.AddConfiguration(new RecipeMap());

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<CookingMethod> CookingMethods { get; set; }
        public DbSet<CookingMethodIngredient> CookingMethodIngredients { get; set; }
        public DbSet<CookingStep> CookingSteps { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<RecipeCategory> RecipeCategories { get; set; }
    }
}