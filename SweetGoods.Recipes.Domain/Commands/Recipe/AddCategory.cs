using SweetGoods.Recipes.Domain.Core.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace SweetGoods.Recipes.Domain.Commands.Recipe
{
    public class AddCategory : RecipeBaseCommand
    {
        public AddCategory(Guid aggregateId, Guid categoryAggregateId)
        {
            AggregateId = aggregateId;
            CategoryAggregateId = categoryAggregateId;
        }

        public Guid CategoryAggregateId { get; private set; }

        public override bool IsValid()
        {
            return true;
        }
    }
}