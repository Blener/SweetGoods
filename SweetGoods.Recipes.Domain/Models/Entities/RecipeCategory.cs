using SweetGoods.Recipes.Domain.Core.Models;
using System;

namespace SweetGoods.Recipes.Domain.Models.Entities
{
    public class RecipeCategory : Entity
    {
        public RecipeCategory(Guid recipeAggregateId, Guid categoryAggregateId, Guid aggregateId)
        {
            RecipeAggregateId = recipeAggregateId;
            CategoryAggregateId = categoryAggregateId;
            AggregateId = aggregateId;
        }

        public RecipeCategory(Guid recipeAggregateId, Guid categoryAggregateId, Guid aggregateId, Recipe recipe, Category category) : this(recipeAggregateId, categoryAggregateId, aggregateId)
        {
            Recipe = recipe;
            Category = category;
        }

        internal RecipeCategory()
        {
        }

        public Guid RecipeAggregateId { get; private set; }

        public Guid CategoryAggregateId { get; private set; }

        public virtual Recipe Recipe { get; private set; }

        public virtual Category Category { get; private set; }
    }
}