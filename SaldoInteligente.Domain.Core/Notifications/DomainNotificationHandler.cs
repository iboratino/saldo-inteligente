using MediatR;

namespace SaldoInteligente.Domain.Core.Notifications
{
    public class DomainNotificationHandler : INotificationHandler<DomainNotification>
    {
        private List<DomainNotification> notifications;

        public DomainNotificationHandler()
        {
            notifications = new List<DomainNotification>();
        }

        public void Handle(DomainNotification notification)
        {
            notifications.Add(notification);
        }

        public virtual IEnumerable<DomainNotification> GetNotifications()
        {
            return notifications;
        }

        public virtual bool HasNotifications()
        {
            return GetNotifications().Any();
        }

        public void Dispose()
        {
            notifications = new List<DomainNotification>();
        }

        public Task Handle(DomainNotification notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
