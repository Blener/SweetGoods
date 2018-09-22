using System;

namespace SweetGoods.Recipes.Domain.Commands.Recipe
{
    public class AddCategory : RecipeBaseCommand
    {
        public AddCategory(Guid aggregateId, Guid recipeAggregateId, Guid categoryAggregateId)
        {
            AggregateId = aggregateId;
            RecipeAggregateId = recipeAggregateId;
            CategoryAggregateId = categoryAggregateId;
        }

        public Guid RecipeAggregateId { get; private set; }

        public Guid CategoryAggregateId { get; private set; }

        public override bool IsValid()
        {
            return true;
        }
    }
}