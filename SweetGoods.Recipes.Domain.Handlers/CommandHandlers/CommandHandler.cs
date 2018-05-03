using MediatR;
using SweetGoods.Recipes.Domain.Core.Bus;
using SweetGoods.Recipes.Domain.Core.Notifications;
using SweetGoods.Recipes.Domain.Interfaces;

namespace SweetGoods.Recipes.Domain.Handlers.CommandHandlers
{
    public class CommandHandler
    {
        private readonly IUnitOfWork _uow;
        protected readonly IMediatorHandler _bus;
        private readonly DomainNotificationHandler _notifications;

        public CommandHandler(IUnitOfWork uow, IMediatorHandler bus, INotificationHandler<DomainNotification> notifications)
        {
            _uow = uow;
            _notifications = (DomainNotificationHandler)notifications;
            _bus = bus;
        }

        public bool Commit()
        {
            if (_notifications.HasErrors()) return false;
            var commandResponse = _uow.Commit();
            if (commandResponse.Success) return true;

            _bus.RaiseEvent(new DomainNotification("Commit", "An error has been raised while saving your data.", false));
            return false;
        }
    }
}