using GiftBagOfBases.Commands;
using System;

namespace SweetGoods.Recipes.Domain.Commands.Recipe
{
    public class RestoreDeletedRecipe : Command
    {
        public RestoreDeletedRecipe(Guid aggregateId)
        {
            AggregateId = aggregateId;
        }

        public override bool IsValid()
        {
            return true;
        }
    }
}