using MediatR;
using System.Collections.Generic;
using System.Linq;

namespace SweetGoods.Recipes.Domain.Core.Notifications
{
    public class DomainNotificationHandler : INotificationHandler<DomainNotification>
    {
        private List<DomainNotification> notifications;

        public DomainNotificationHandler()
        {
            notifications = new List<DomainNotification>();
        }

        public void Handle(DomainNotification notification) => notifications.Add(notification);

        public virtual List<DomainNotification> GetNotifications() => notifications;

        public virtual List<DomainNotification> GetErrors() => notifications.Where(x => !x.Success).ToList();

        public virtual List<DomainNotification> GetConfirmations() => notifications.Where(x => x.Success).ToList();

        public virtual bool HasNotifications() => GetNotifications().Count > 0;

        public virtual bool HasErrors() => GetErrors().Count > 0;

        public void Dispose() => notifications = new List<DomainNotification>();
    }
}