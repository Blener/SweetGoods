using MediatR;
using SweetGoods.Recipes.Domain.Events.CookingMethod;
using System.Threading;
using System.Threading.Tasks;

namespace SweetGoods.Recipes.Domain.Handlers.EventHandlers
{
    public class CookingMethodEventHandler : INotificationHandler<NewCookingMethodAdded>,
                                             INotificationHandler<CookingMethodDeleted>,
                                             INotificationHandler<CookingMethodUpdated>,
                                             INotificationHandler<DeletedCookingMethodRestored>,
                                             INotificationHandler<CookingMethodIngredientAdded>,
                                             INotificationHandler<CookingStepAdded>
    {
        public async Task Handle(NewCookingMethodAdded notification, CancellationToken cancellationToken)
        {
        }

        public async Task Handle(CookingMethodDeleted notification, CancellationToken cancellationToken)
        {
        }

        public async Task Handle(CookingMethodUpdated notification, CancellationToken cancellationToken)
        {
        }

        public async Task Handle(DeletedCookingMethodRestored notification, CancellationToken cancellationToken)
        {
        }

        public async Task Handle(CookingMethodIngredientAdded notification, CancellationToken cancellationToken)
        {
        }

        public async Task Handle(CookingStepAdded notification, CancellationToken cancellationToken)
        {
        }
    }
}