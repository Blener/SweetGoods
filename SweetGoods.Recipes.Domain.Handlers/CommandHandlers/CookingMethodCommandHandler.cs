using GiftBagOfBases.Commands;
using GiftBagOfBases.Interfaces.Domain;
using GiftBagOfBases.Notifications;
using MediatR;
using SweetGoods.Recipes.Domain.Commands.CookingMethod;
using SweetGoods.Recipes.Domain.Events.CookingMethod;
using SweetGoods.Recipes.Domain.Interfaces.Commands;
using SweetGoods.Recipes.Domain.Interfaces.Queries;
using SweetGoods.Recipes.Domain.Models.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace SweetGoods.Recipes.Domain.Handlers.CommandHandlers
{
    public class CookingMethodCommandHandler : CommandHandler,
                                               INotificationHandler<AddNewCookingMethod>,
                                               INotificationHandler<UpdateCookingMethod>,
                                               INotificationHandler<DeleteCookingMethod>,
                                               INotificationHandler<RestoreDeletedCookingMethod>,
                                               INotificationHandler<AddIngredient>,
                                               INotificationHandler<AddStep>
    {
        private readonly ICookingMethodCommandRepository cookingMethodCommandRepository;
        private readonly ICookingMethodQueryRepository cookingMethodQueryRepository;
        private readonly IRecipeQueryRepository recipeQueryRepository;
        private readonly IIngredientQueryRepository ingredientQueryRepository;

        public CookingMethodCommandHandler(IUnitOfWork uow,
                                           IMediatorHandler bus,
                                           INotificationHandler<DomainNotification> notifications,
                                           ICookingMethodCommandRepository cookingMethodCommandRepository,
                                           ICookingMethodQueryRepository cookingMethodQueryRepository,
                                           IRecipeQueryRepository recipeQueryRepository,
                                           IIngredientQueryRepository ingredientQueryRepository) : base(uow, bus, notifications)
        {
            this.cookingMethodCommandRepository = cookingMethodCommandRepository;
            this.cookingMethodQueryRepository = cookingMethodQueryRepository;
            this.recipeQueryRepository = recipeQueryRepository;
            this.ingredientQueryRepository = ingredientQueryRepository;
        }

        public async Task Handle(AddNewCookingMethod notification, CancellationToken cancellationToken)
        {
            var cookingMethod = new CookingMethod(notification.RecipeAggregateId, notification.CookingTime, notification.Description);

            cookingMethodCommandRepository.Add(cookingMethod);

            if (Commit())
            {
                await _bus.RaiseEvent(new NewCookingMethodAdded(cookingMethod.Id, cookingMethod.CookingTime, cookingMethod.Description));
            }
        }

        public async Task Handle(UpdateCookingMethod notification, CancellationToken cancellationToken)
        {
            var cookingMethodDb = await cookingMethodQueryRepository.Get(notification.AggregateId);

            if (cookingMethodDb == null)
            {
                await RaiseDomainError(notification, "Couldn't find the requested cooking method.");
                return;
            }

            var cookingMethod = new CookingMethod(cookingMethodDb.IncrementId, cookingMethodDb.Id, cookingMethodDb.RecipeId, notification.CookingTime, notification.Description, cookingMethodDb.SoftDeleted);

            cookingMethodCommandRepository.Update(cookingMethod);

            if (Commit())
            {
                await _bus.RaiseEvent(new CookingMethodUpdated(cookingMethod.Id, cookingMethod.CookingTime, cookingMethod.Description));
            }
        }

        public async Task Handle(DeleteCookingMethod notification, CancellationToken cancellationToken)
        {
            await cookingMethodCommandRepository.Remove(notification.AggregateId);

            if (Commit())
            {
                await _bus.RaiseEvent(new CookingMethodDeleted(notification.AggregateId));
            }
        }

        public async Task Handle(RestoreDeletedCookingMethod notification, CancellationToken cancellationToken)
        {
            var cookingMethodDb = await cookingMethodQueryRepository.Get(notification.AggregateId);

            if (cookingMethodDb == null)
            {
                await RaiseDomainError(notification, "Couldn't find the requested cooking method.");
                return;
            }

            cookingMethodDb.Rebirth();

            cookingMethodCommandRepository.Update(cookingMethodDb);

            if (Commit())
            {
                await _bus.RaiseEvent(new DeletedCookingMethodRestored(notification.AggregateId));
            }
        }

        public async Task Handle(AddIngredient notification, CancellationToken cancellationToken)
        {
            var cookingMethodExist = await cookingMethodQueryRepository.ExistAggregateId(notification.AggregateId);
            if (!cookingMethodExist)
            {
                await RaiseDomainError(notification, "Couldn't find the requested cooking method");
            }

            var ingredientExist = await ingredientQueryRepository.ExistAggregateId(notification.IngredientAggregateId);
            if (!ingredientExist)
            {
                await RaiseDomainError(notification, "Couldn't find the requested ingredient");
            }

            var cookingMethodIngredient = new CookingMethodIngredient(
                notification.CookingMethodAggregateId,
                notification.IngredientAggregateId,
                notification.AggregateId,
                notification.MeasureType,
                notification.Measure,
                notification.Usage);

            cookingMethodCommandRepository.AddRelation(cookingMethodIngredient);

            if (Commit())
            {
                await _bus.RaiseEvent(new CookingMethodIngredientAdded(
                    notification.AggregateId,
                    notification.IngredientAggregateId,
                    notification.MeasureType,
                    notification.Measure,
                    notification.Usage));
            }
        }

        public async Task Handle(AddStep notification, CancellationToken cancellationToken)
        {
            var cookingMethodExist = await cookingMethodQueryRepository.ExistAggregateId(notification.AggregateId);
            if (!cookingMethodExist)
            {
                await RaiseDomainError(notification, "Couldn't find the requested cooking method");
            }

            var cookingStep = new CookingStep(notification.AggregateId, notification.CookingMethodAggregateId, notification.StepNumber, notification.StepAction);

            cookingMethodCommandRepository.AddRelation(cookingStep);

            if (Commit())
            {
                await _bus.RaiseEvent(new CookingStepAdded(notification.AggregateId, notification.CookingMethodAggregateId, notification.StepNumber, notification.StepAction));
            }
        }
    }
}