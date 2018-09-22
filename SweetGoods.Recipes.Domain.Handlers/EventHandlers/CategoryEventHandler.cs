using MediatR;
using SweetGoods.Recipes.Domain.Events.Category;
using System.Threading;
using System.Threading.Tasks;

namespace SweetGoods.Recipes.Domain.Handlers.EventHandlers
{
    public class CategoryEventHandler : INotificationHandler<NewCategoryAdded>,
                                        INotificationHandler<CategoryDeleted>,
                                        INotificationHandler<CategoryUpdated>,
                                        INotificationHandler<DeletedCategoryRestored>
    {
        public async Task Handle(NewCategoryAdded notification, CancellationToken cancellationToken)
        {
        }

        public async Task Handle(CategoryDeleted notification, CancellationToken cancellationToken)
        {
        }

        public async Task Handle(CategoryUpdated notification, CancellationToken cancellationToken)
        {
        }

        public async Task Handle(DeletedCategoryRestored notification, CancellationToken cancellationToken)
        {
        }
    }
}