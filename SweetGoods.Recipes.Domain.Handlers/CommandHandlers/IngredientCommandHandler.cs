using GiftBagOfBases.Commands;
using GiftBagOfBases.Interfaces.Domain;
using GiftBagOfBases.Notifications;
using MediatR;
using SweetGoods.Recipes.Domain.Commands.Ingredient;
using SweetGoods.Recipes.Domain.Events.Ingredient;
using SweetGoods.Recipes.Domain.Interfaces.Commands;
using SweetGoods.Recipes.Domain.Interfaces.Queries;
using SweetGoods.Recipes.Domain.Models.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace SweetGoods.Recipes.Domain.Handlers.CommandHandlers
{
    public class IngredientCommandHandler : CommandHandler,
                                            INotificationHandler<AddNewIngredient>,
                                            INotificationHandler<UpdateIngredient>,
                                            INotificationHandler<DeleteIngredient>,
                                            INotificationHandler<RestoreDeletedIngredient>
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

        public async Task Handle(AddNewIngredient notification, CancellationToken cancellationToken)
        {
            var ingredient = new Ingredient(notification.Name, notification.Details);

            ingredientCommandRepository.Add(ingredient);

            if (Commit())
            {
                await _bus.RaiseEvent(new NewIngredientAdded(ingredient.Id, ingredient.Name, ingredient.Details));
            }
        }

        public async Task Handle(UpdateIngredient notification, CancellationToken cancellationToken)
        {
            var ingredientDb = await ingredientQueryRepository.Get(notification.AggregateId);

            if (ingredientDb == null)
            {
                await RaiseDomainError(notification, "Couldn't find the requested ingredient.");
                return;
            }

            var ingredient = new Ingredient(ingredientDb.IncrementId, ingredientDb.Id, notification.Name, notification.Details, ingredientDb.SoftDeleted);

            ingredientCommandRepository.Update(ingredient);

            if (Commit())
            {
                await _bus.RaiseEvent(new IngredientUpdated(ingredient.Id, ingredient.Name, ingredient.Details));
            }
        }

        public async Task Handle(DeleteIngredient notification, CancellationToken cancellationToken)
        {
            await ingredientCommandRepository.Remove(notification.AggregateId);

            if (Commit())
            {
                await _bus.RaiseEvent(new IngredientDeleted(notification.AggregateId));
            }
        }

        public async Task Handle(RestoreDeletedIngredient notification, CancellationToken cancellationToken)
        {
            var ingredientDb = await ingredientQueryRepository.Get(notification.AggregateId);

            if (ingredientDb == null)
            {
                await RaiseDomainError(notification, "Couldn't find the requested ingredient.");
                return;
            }

            ingredientDb.Rebirth();

            ingredientCommandRepository.Update(ingredientDb);

            if (Commit())
            {
                await _bus.RaiseEvent(new DeletedIngredientRestored(notification.AggregateId));
            }
        }
    }
}