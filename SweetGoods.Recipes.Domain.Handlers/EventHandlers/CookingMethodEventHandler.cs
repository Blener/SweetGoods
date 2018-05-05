using MediatR;
using SweetGoods.Recipes.Domain.Events.CookingMethod;
using System.Threading.Tasks;

namespace SweetGoods.Recipes.Domain.Handlers.EventHandlers
{
    public class CookingMethodEventHandler : IAsyncNotificationHandler<NewCookingMethodAdded>,
                                             IAsyncNotificationHandler<CookingMethodDeleted>,
                                             IAsyncNotificationHandler<CookingMethodUpdated>,
                                             IAsyncNotificationHandler<DeletedCookingMethodRestored>,
                                             IAsyncNotificationHandler<CookingMethodIngredientAdded>,
                                             IAsyncNotificationHandler<CookingStepAdded>
    {
        public async Task Handle(NewCookingMethodAdded notification)
        {
        }

        public async Task Handle(CookingMethodDeleted notification)
        {
        }

        public async Task Handle(CookingMethodUpdated notification)
        {
        }

        public async Task Handle(DeletedCookingMethodRestored notification)
        {
        }

        public async Task Handle(CookingMethodIngredientAdded notification)
        {
        }

        public async Task Handle(CookingStepAdded notification)
        {
        }
    }
}