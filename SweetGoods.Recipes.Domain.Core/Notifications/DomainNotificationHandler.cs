using MediatR;
using System.Collections.Generic;
using System.Linq;

namespace SweetGoods.Recipes.Domain.Core.Notifications
{
    public class DomainNotificationHandler : INotificationHandler<DomainNotification>
    {
        private List<DomainNotification> _notifications;

        public DomainNotificationHandler()
        {
            _notifications = new List<DomainNotification>();
        }

        public void Handle(DomainNotification message)
        {
            _notifications.Add(message);
        }

        public virtual List<DomainNotification> GetNotifications() => _notifications;

        public virtual List<DomainNotification> GetErrors() => _notifications.Where(x => !x.Success).ToList();

        public virtual List<DomainNotification> GetConfirmations() => _notifications.Where(x => x.Success).ToList();

        public virtual bool HasErrors() => GetNotifications().Any(x => !x.Success);

        public void Dispose() => _notifications = new List<DomainNotification>();
    }
}