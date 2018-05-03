using System;

namespace SweetGoods.Recipes.Domain.Commands.Ingredient
{
    public class DeleteIngredient : IngredientBaseCommand
    {
        public DeleteIngredient(Guid aggregateId)
        {
            AggregateId = aggregateId;
        }

        public override bool IsValid()
        {
            return true;
        }
    }
}