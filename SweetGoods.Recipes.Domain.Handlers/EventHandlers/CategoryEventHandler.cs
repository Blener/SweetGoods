using MediatR;
using SweetGoods.Recipes.Domain.Events.Category;
using System.Threading.Tasks;

namespace SweetGoods.Recipes.Domain.Handlers.EventHandlers
{
    public class CategoryEventHandler : IAsyncNotificationHandler<NewCategoryAdded>,
                                        IAsyncNotificationHandler<CategoryDeleted>,
                                        IAsyncNotificationHandler<CategoryUpdated>,
                                        IAsyncNotificationHandler<DeletedCategoryRestored>
    {
        public async Task Handle(NewCategoryAdded notification)
        {
        }

        public async Task Handle(CategoryDeleted notification)
        {
        }

        public async Task Handle(CategoryUpdated notification)
        {
        }

        public async Task Handle(DeletedCategoryRestored notification)
        {
        }
    }
}