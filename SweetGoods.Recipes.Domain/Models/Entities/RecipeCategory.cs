using GiftBagOfBases.Models;
using System;

namespace SweetGoods.Recipes.Domain.Models.Entities
{
    public class RecipeCategory : Entity
    {
        public RecipeCategory(Guid recipeId, Guid categoryId, Guid id)
        {
            RecipeId = recipeId;
            CategoryId = categoryId;
            Id = id;
        }

        public RecipeCategory(Guid recipeId, Guid categoryId, Guid id, Recipe recipe, Category category) : this(recipeId, categoryId, id)
        {
            Recipe = recipe;
            Category = category;
        }

        internal RecipeCategory()
        {
        }

        public Guid RecipeId { get; private set; }

        public Guid CategoryId { get; private set; }

        public virtual Recipe Recipe { get; private set; }

        public virtual Category Category { get; private set; }
    }
}