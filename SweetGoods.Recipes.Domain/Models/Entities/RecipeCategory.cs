using SweetGoods.Recipes.Domain.Core.Models;

namespace SweetGoods.Recipes.Domain.Models.Entities
{
    public class RecipeCategory : Entity
    {
        public RecipeCategory(int recipeId, int categoryId, Recipe recipe, Category category)
        {
            RecipeId = recipeId;
            CategoryId = categoryId;
            Recipe = recipe;
            Category = category;
        }

        internal RecipeCategory()
        {
        }

        public int RecipeId { get; }

        public int CategoryId { get; }

        public virtual Recipe Recipe { get; }

        public virtual Category Category { get; }
    }
}