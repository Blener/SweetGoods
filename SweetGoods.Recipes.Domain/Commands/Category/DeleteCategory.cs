using System;

namespace SweetGoods.Recipes.Domain.Commands.Category
{
    public class DeleteCategory : CategoryBaseCommand
    {
        protected DeleteCategory(Guid aggregateId)
        {
            AggregateId = aggregateId;
        }

        public override bool IsValid()
        {
            return true;
        }
    }
}