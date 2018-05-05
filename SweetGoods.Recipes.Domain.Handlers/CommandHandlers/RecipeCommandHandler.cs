using MediatR;
using SweetGoods.Recipes.Domain.Commands.Recipe;
using SweetGoods.Recipes.Domain.Interfaces;
using SweetGoods.Recipes.Domain.Core.Bus;
using SweetGoods.Recipes.Domain.Core.Notifications;
using SweetGoods.Recipes.Domain.Interfaces.Commands;
using SweetGoods.Recipes.Domain.Interfaces.Queries;
using SweetGoods.Recipes.Domain.Models.Entities;
using SweetGoods.Recipes.Domain.Events.Recipe;
using System.Threading.Tasks;

namespace SweetGoods.Recipes.Domain.Handlers.CommandHandlers
{
    public class RecipeCommandHandler : CommandHandler,
                                        IAsyncNotificationHandler<AddNewRecipe>,
                                        IAsyncNotificationHandler<UpdateRecipe>,
                                        IAsyncNotificationHandler<DeleteRecipe>,
                                        IAsyncNotificationHandler<RestoreDeletedRecipe>
    {
        private readonly IRecipeCommandRepository recipeCommandRepository;
        private readonly IRecipeQueryRepository recipeQueryRepository;

        public RecipeCommandHandler(IUnitOfWork uow,
                                    IMediatorHandler bus,
                                    INotificationHandler<DomainNotification> notifications,
                                    IRecipeCommandRepository recipeCommandRepository,
                                    IRecipeQueryRepository recipeQueryRepository) : base(uow, bus, notifications)
        {
            this.recipeCommandRepository = recipeCommandRepository;
            this.recipeQueryRepository = recipeQueryRepository;
        }

        public async Task Handle(AddNewRecipe notification)
        {
            if (await recipeQueryRepository.NameExist(notification.Name.Name))
            {
                await RaiseDomainError(notification, "A recipe with that name already exist.");
                return;
            }

            var recipe = new Recipe(notification.Name, notification.Description);

            recipeCommandRepository.Add(recipe);

            if (Commit())
            {
                await _bus.RaiseEvent(new NewRecipeAdded(recipe.AggregateId, recipe.Name, recipe.Description));
            }
        }

        public async Task Handle(UpdateRecipe notification)
        {
            var recipeDb = await recipeQueryRepository.GetByAggregateId(notification.AggregateId);

            if (recipeDb == null)
            {
                await RaiseDomainError(notification, "Couldn't find the requested recipe.");
                return;
            }

            var recipe = new Recipe(recipeDb.Id, recipeDb.AggregateId, notification.Name, notification.Description, recipeDb.SoftDeleted);

            recipeCommandRepository.Update(recipe);

            if (Commit())
            {
                await _bus.RaiseEvent(new RecipeUpdated(recipe.AggregateId, recipe.Name, recipe.Description));
            }
        }

        public async Task Handle(DeleteRecipe notification)
        {
            await recipeCommandRepository.Remove(notification.AggregateId);

            if (Commit())
            {
                await _bus.RaiseEvent(new RecipeDeleted(notification.AggregateId));
            }
        }

        public async Task Handle(RestoreDeletedRecipe notification)
        {
            var recipeDb = await recipeQueryRepository.GetByAggregateId(notification.AggregateId);

            if (recipeDb == null)
            {
                await RaiseDomainError(notification, "Couldn't find the requested recipe.");
                return;
            }

            var restoredRecipe = recipeDb.GetRestored();

            recipeCommandRepository.Update(restoredRecipe);

            if (Commit())
            {
                await _bus.RaiseEvent(new DeletedRecipeRestored(notification.AggregateId));
            }
        }
    }
}