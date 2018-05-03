using MediatR;
using SweetGoods.Recipes.Domain.Commands.Category;
using SweetGoods.Recipes.Domain.Core.Bus;
using SweetGoods.Recipes.Domain.Core.Notifications;
using SweetGoods.Recipes.Domain.Events.Category;
using SweetGoods.Recipes.Domain.Interfaces;
using SweetGoods.Recipes.Domain.Interfaces.Commands;
using SweetGoods.Recipes.Domain.Interfaces.Queries;
using SweetGoods.Recipes.Domain.Models.Entities;
using System.Threading.Tasks;

namespace SweetGoods.Recipes.Domain.Handlers.CommandHandlers
{
    public class CategoryCommandHandler : CommandHandler,
                                          IAsyncNotificationHandler<AddNewCategory>,
                                          IAsyncNotificationHandler<UpdateCategory>,
                                          IAsyncNotificationHandler<DeleteCategory>,
                                          IAsyncNotificationHandler<RestoreDeletedCategory>
    {
        private readonly ICategoryCommandRepository categoryCommandRepository;
        private readonly ICategoryQueryRepository categoryQueryRepository;

        public CategoryCommandHandler(IUnitOfWork uow,
                                    IMediatorHandler bus,
                                    INotificationHandler<DomainNotification> notifications,
                                    ICategoryCommandRepository categoryCommandRepository,
                                    ICategoryQueryRepository categoryQueryRepository) : base(uow, bus, notifications)
        {
            this.categoryCommandRepository = categoryCommandRepository;
            this.categoryQueryRepository = categoryQueryRepository;
        }

        public async Task Handle(AddNewCategory notification)
        {
            if (await categoryQueryRepository.NameExist(notification.Name.Name))
            {
                await _bus.RaiseEvent(notification.RaiseError("A category with that name already exist."));
                return;
            }

            var category = new Category(notification.Name, notification.Description, notification.CategoryType);

            categoryCommandRepository.Add(category);

            if (Commit())
            {
                await _bus.RaiseEvent(new NewCategoryAdded(category.AggregateId, category.Name, category.Description, category.CategoryType));
            }
        }

        public async Task Handle(UpdateCategory notification)
        {
            var categoryDb = await categoryQueryRepository.GetByAggregateId(notification.AggregateId);

            if (categoryDb == null)
            {
                await _bus.RaiseEvent(notification.RaiseError("Couldn't find the requested category."));
                return;
            }

            var category = new Category(categoryDb.Id, categoryDb.AggregateId, notification.Name, notification.Description, notification.CategoryType, categoryDb.SoftDeleted);

            categoryCommandRepository.Update(category);

            if (Commit())
            {
                await _bus.RaiseEvent(new CategoryUpdated(category.AggregateId, category.Name, category.Description, category.CategoryType));
            }
        }

        public async Task Handle(DeleteCategory notification)
        {
            categoryCommandRepository.Remove(notification.AggregateId);

            if (Commit())
            {
                await _bus.RaiseEvent(new CategoryDeleted(notification.AggregateId));
            }
        }

        public async Task Handle(RestoreDeletedCategory notification)
        {
            var categoryDb = await categoryQueryRepository.GetByAggregateId(notification.AggregateId);

            if (categoryDb == null)
            {
                await _bus.RaiseEvent(notification.RaiseError("Couldn't find the requested category."));
                return;
            }

            categoryDb.RestoreDeleted();

            categoryCommandRepository.Update(categoryDb);

            if (Commit())
            {
                await _bus.RaiseEvent(new DeletedCategoryRestored(notification.AggregateId));
            }
        }
    }
}