using SweetGoods.Recipes.Domain.Core.Events;
using System;
using System.Collections.Generic;

namespace SweetGoods.Recipes.Infra.Data.Repositories.EventSourcing
{
    public interface IEventStoreRepository : IDisposable
    {
        void Store(StoredEvent theEvent);

        IList<StoredEvent> All(Guid aggregateId);
    }
}