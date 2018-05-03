using SweetGoods.Recipes.Domain.Core.Events;
using System;

namespace SweetGoods.Recipes.Domain.Events.Category
{
    public class DeletedCategoryRestored : Event
    {
        public DeletedCategoryRestored(Guid aggregateId)
        {
            AggregateId = aggregateId;
        }
    }
}