using MediatR;
using SweetGoods.Recipes.Domain.Events.CookingMethod;
using SweetGoods.Recipes.Domain.Events.Recipe;
using System.Threading.Tasks;

namespace SweetGoods.Recipes.Domain.Handlers.EventHandlers
{
    public class RecipeEventHandler : IAsyncNotificationHandler<NewRecipeAdded>,
                                      IAsyncNotificationHandler<RecipeDeleted>,
                                      IAsyncNotificationHandler<RecipeUpdated>,
                                      IAsyncNotificationHandler<DeletedRecipeRestored>
    {
        public async Task Handle(NewRecipeAdded notification)
        {
        }

        public async Task Handle(RecipeDeleted notification)
        {
        }

        public async Task Handle(RecipeUpdated notification)
        {
        }

        public async Task Handle(DeletedRecipeRestored notification)
        {
        }
    }
}