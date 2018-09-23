using GiftBagOfBases.Contexts;
using Microsoft.EntityFrameworkCore;
using SweetGoods.Recipes.Domain.Models.Entities;
using SweetGoods.Recipes.Infra.Data.Mappings;

namespace SweetGoods.Recipes.Infra.Data.Context
{
    public class SweetGoodsRecipesContext : GiftContext<SweetGoodsRecipesContext>
    {
        public SweetGoodsRecipesContext(DbContextOptions<SweetGoodsRecipesContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryMap());
            modelBuilder.ApplyConfiguration(new CookingMethodMap());
            modelBuilder.ApplyConfiguration(new CookingMethodIngredientMap());
            modelBuilder.ApplyConfiguration(new CookingStepsMap());
            modelBuilder.ApplyConfiguration(new IngredientMap());
            modelBuilder.ApplyConfiguration(new RecipeCategoryMap());
            modelBuilder.ApplyConfiguration(new RecipeMap());

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