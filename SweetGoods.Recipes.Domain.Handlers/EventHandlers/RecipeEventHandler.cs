using MediatR;
using SweetGoods.Recipes.Domain.Events.Recipe;
using System.Threading;
using System.Threading.Tasks;

namespace SweetGoods.Recipes.Domain.Handlers.EventHandlers
{
    public class RecipeEventHandler : INotificationHandler<NewRecipeAdded>,
                                      INotificationHandler<RecipeDeleted>,
                                      INotificationHandler<RecipeUpdated>,
                                      INotificationHandler<DeletedRecipeRestored>,
                                      INotificationHandler<RecipeCategoryAdded>
    {
        public async Task Handle(NewRecipeAdded notification, CancellationToken cancellationToken)
        {
        }

        public async Task Handle(RecipeDeleted notification, CancellationToken cancellationToken)
        {
        }

        public async Task Handle(RecipeUpdated notification, CancellationToken cancellationToken)
        {
        }

        public async Task Handle(DeletedRecipeRestored notification, CancellationToken cancellationToken)
        {
        }

        public async Task Handle(RecipeCategoryAdded notification, CancellationToken cancellationToken)
        {
        }
    }
}