using System.Threading.Tasks;
using MediatR;
using SweetGoods.Recipes.Domain.Commands.Ingredient;
using SweetGoods.Recipes.Domain.Core.Bus;
using SweetGoods.Recipes.Domain.Core.Notifications;
using SweetGoods.Recipes.Domain.Events.Ingredient;
using SweetGoods.Recipes.Domain.Interfaces;
using SweetGoods.Recipes.Domain.Interfaces.Commands;
using SweetGoods.Recipes.Domain.Interfaces.Queries;
using SweetGoods.Recipes.Domain.Models.Entities;

namespace SweetGoods.Recipes.Domain.Handlers.CommandHandlers
{
    public class IngredientCommandHandler : CommandHandler,
                                            IAsyncNotificationHandler<AddNewIngredient>,
                                            IAsyncNotificationHandler<UpdateIngredient>,
                                            IAsyncNotificationHandler<DeleteIngredient>,
                                            IAsyncNotificationHandler<RestoreDeletedIngredient>
    {
        private readonly IIngredientCommandRepository ingredientCommandRepository;
        private readonly IIngredientQueryRepository ingredientQueryRepository;

        public IngredientCommandHandler(
            IUnitOfWork uow,
            IMediatorHandler bus,
            INotificationHandler<DomainNotification> notifications,
            IIngredientCommandRepository ingredientCommandRepository,
            IIngredientQueryRepository ingredientQueryRepository) : base(uow, bus, notifications)
        {
            this.ingredientCommandRepository = ingredientCommandRepository;
            this.ingredientQueryRepository = ingredientQueryRepository;
        }

        public async Task Handle(AddNewIngredient notification)
        {
            var ingredient = new Ingredient(notification.Name, notification.Details);

            ingredientCommandRepository.Add(ingredient);

            if (Commit())
            {
                await _bus.RaiseEvent(new NewIngredientAdded(ingredient.AggregateId, ingredient.Name, ingredient.Details));
            }
        }

        public async Task Handle(UpdateIngredient notification)
        {
            var ingredientDb = await ingredientQueryRepository.GetByAggregateId(notification.AggregateId);

            if (ingredientDb == null)
            {
                await RaiseDomainError(notification, "Couldn't find the requested ingredient.");
                return;
            }

            var ingredient = new Ingredient(ingredientDb.Id, ingredientDb.AggregateId, notification.Name, notification.Details, ingredientDb.SoftDeleted);

            ingredientCommandRepository.Update(ingredient);

            if (Commit())
            {
                await _bus.RaiseEvent(new IngredientUpdated(ingredient.AggregateId, ingredient.Name, ingredient.Details));
            }
        }

        public async Task Handle(DeleteIngredient notification)
        {
            await ingredientCommandRepository.Remove(notification.AggregateId);

            if (Commit())
            {
                await _bus.RaiseEvent(new IngredientDeleted(notification.AggregateId));
            }
        }

        public async Task Handle(RestoreDeletedIngredient notification)
        {
            var ingredientDb = await ingredientQueryRepository.GetByAggregateId(notification.AggregateId);

            if (ingredientDb == null)
            {
                await RaiseDomainError(notification, "Couldn't find the requested ingredient.");
                return;
            }

            var restoredIngredient = ingredientDb.GetRestored();

            ingredientCommandRepository.Update(restoredIngredient);

            if (Commit())
            {
                await _bus.RaiseEvent(new DeletedIngredientRestored(notification.AggregateId));
            }
        }
    }
}