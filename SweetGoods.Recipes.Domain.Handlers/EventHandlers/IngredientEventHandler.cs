using MediatR;
using SweetGoods.Recipes.Domain.Events.CookingMethod;
using SweetGoods.Recipes.Domain.Events.Ingredient;
using System.Threading.Tasks;

namespace SweetGoods.Recipes.Domain.Handlers.EventHandlers
{
    public class IngredientEventHandler : IAsyncNotificationHandler<NewIngredientAdded>,
                                          IAsyncNotificationHandler<IngredientDeleted>,
                                          IAsyncNotificationHandler<IngredientUpdated>,
                                          IAsyncNotificationHandler<DeletedIngredientRestored>
    {
        public async Task Handle(NewIngredientAdded notification)
        {
        }

        public async Task Handle(IngredientDeleted notification)
        {
        }

        public async Task Handle(IngredientUpdated notification)
        {
        }

        public async Task Handle(DeletedIngredientRestored notification)
        {
        }
    }
}