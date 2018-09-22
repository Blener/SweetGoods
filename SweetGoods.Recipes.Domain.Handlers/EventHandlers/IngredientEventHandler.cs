using MediatR;
using SweetGoods.Recipes.Domain.Events.Ingredient;
using System.Threading;
using System.Threading.Tasks;

namespace SweetGoods.Recipes.Domain.Handlers.EventHandlers
{
    public class IngredientEventHandler : INotificationHandler<NewIngredientAdded>,
                                          INotificationHandler<IngredientDeleted>,
                                          INotificationHandler<IngredientUpdated>,
                                          INotificationHandler<DeletedIngredientRestored>
    {
        public async Task Handle(NewIngredientAdded notification, CancellationToken cancellationToken)
        {
        }

        public async Task Handle(IngredientDeleted notification, CancellationToken cancellationToken)
        {
        }

        public async Task Handle(IngredientUpdated notification, CancellationToken cancellationToken)
        {
        }

        public async Task Handle(DeletedIngredientRestored notification, CancellationToken cancellationToken)
        {
        }
    }
}