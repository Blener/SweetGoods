using GiftBagOfBases.Commands;
using GiftBagOfBases.Interfaces.Domain;
using GiftBagOfBases.Notifications;
using MediatR;
using SweetGoods.Recipes.Domain.Commands.Recipe;
using SweetGoods.Recipes.Domain.Events.Recipe;
using SweetGoods.Recipes.Domain.Interfaces.Commands;
using SweetGoods.Recipes.Domain.Interfaces.Queries;
using SweetGoods.Recipes.Domain.Models.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace SweetGoods.Recipes.Domain.Handlers.CommandHandlers
{
    public class RecipeCommandHandler : CommandHandler,
                                        INotificationHandler<AddNewRecipe>,
                                        INotificationHandler<UpdateRecipe>,
                                        INotificationHandler<DeleteRecipe>,
                                        INotificationHandler<RestoreDeletedRecipe>,
                                        INotificationHandler<AddCategory>
    {
        private readonly IRecipeCommandRepository recipeCommandRepository;
        private readonly IRecipeQueryRepository recipeQueryRepository;
        private readonly ICategoryQueryRepository categoryQueryRepository;

        public RecipeCommandHandler(IUnitOfWork uow,
                                    IMediatorHandler bus,
                                    INotificationHandler<DomainNotification> notifications,
                                    IRecipeCommandRepository recipeCommandRepository,
                                    IRecipeQueryRepository recipeQueryRepository,
                                    ICategoryQueryRepository categoryQueryRepository) : base(uow, bus, notifications)
        {
            this.recipeCommandRepository = recipeCommandRepository;
            this.recipeQueryRepository = recipeQueryRepository;
            this.categoryQueryRepository = categoryQueryRepository;
        }

        public async Task Handle(AddNewRecipe notification, CancellationToken cancellationToken)
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
                await _bus.RaiseEvent(new NewRecipeAdded(recipe.Id, recipe.Name, recipe.Description));
            }
        }

        public async Task Handle(UpdateRecipe notification, CancellationToken cancellationToken)
        {
            var recipeDb = await recipeQueryRepository.GetByAggregateId(notification.AggregateId);

            if (recipeDb == null)
            {
                await RaiseDomainError(notification, "Couldn't find the requested recipe.");
                return;
            }

            var recipe = new Recipe(recipeDb.IncrementId, recipeDb.Id, notification.Name, notification.Description, recipeDb.SoftDeleted);

            recipeCommandRepository.Update(recipe);

            if (Commit())
            {
                await _bus.RaiseEvent(new RecipeUpdated(recipe.Id, recipe.Name, recipe.Description));
            }
        }

        public async Task Handle(DeleteRecipe notification, CancellationToken cancellationToken)
        {
            await recipeCommandRepository.Remove(notification.AggregateId);

            if (Commit())
            {
                await _bus.RaiseEvent(new RecipeDeleted(notification.AggregateId));
            }
        }

        public async Task Handle(RestoreDeletedRecipe notification, CancellationToken cancellationToken)
        {
            var recipeDb = await recipeQueryRepository.GetByAggregateId(notification.AggregateId);

            if (recipeDb == null)
            {
                await RaiseDomainError(notification, "Couldn't find the requested recipe.");
                return;
            }

            recipeDb.Rebirth();

            recipeCommandRepository.Update(recipeDb);

            if (Commit())
            {
                await _bus.RaiseEvent(new DeletedRecipeRestored(notification.AggregateId));
            }
        }

        public async Task Handle(AddCategory notification, CancellationToken cancellationToken)
        {
            var recipeExist = await recipeQueryRepository.ExistAggregateId(notification.AggregateId);
            if (!recipeExist)
            {
                await RaiseDomainError(notification, "Couldn't find the requested recipe");
                return;
            }

            var categoryExist = await categoryQueryRepository.ExistAggregateId(notification.CategoryAggregateId);
            if (!categoryExist)
            {
                await RaiseDomainError(notification, "Couldn't find the requested category");
                return;
            }

            var recipeCategory = new RecipeCategory(notification.RecipeAggregateId, notification.CategoryAggregateId, notification.AggregateId);

            recipeCommandRepository.AddRelation(recipeCategory);

            if (Commit())
            {
                await _bus.RaiseEvent(new RecipeCategoryAdded(notification.AggregateId, notification.CategoryAggregateId));
            }
        }
    }
}