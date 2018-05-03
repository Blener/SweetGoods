using Newtonsoft.Json;
using SweetGoods.Recipes.Domain.Core.Events;
using SweetGoods.Recipes.Infra.Data.Repositories.EventSourcing;

namespace SweetGoods.Recipes.Infra.Data.EventSourcing
{
    public class SqlEventStore : IEventStore
    {
        private readonly IEventStoreRepository eventStoreRepository;

        public SqlEventStore(IEventStoreRepository eventStoreRepository)
        {
            this.eventStoreRepository = eventStoreRepository;
        }

        public void Save<T>(T theEvent) where T : Event
        {
            var serializedData = JsonConvert.SerializeObject(theEvent);

            var storedEvent = new StoredEvent(theEvent, serializedData, "");

            eventStoreRepository.Store(storedEvent);
        }
    }
}