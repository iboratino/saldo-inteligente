using MediatR;
using SaldoInteligente.Domain.Core.Notifications;

namespace SaldoInteligente.Domain.Core.Commands
{
    public abstract class CommandHandler    {

        private readonly DomainNotificationHandler notifications;

        public CommandHandler(INotificationHandler<DomainNotification> notifications)
        {
            this.notifications = (DomainNotificationHandler)notifications;
        }

        protected void NotifyValidationErrors<T>(Command<T> message)
        {
            foreach (var error in message.ValidationResult.Errors)
                notifications.Handle(new DomainNotification(error.PropertyName, error.ErrorMessage));
        }

        protected void NotifyValidationErrors(Command message, string group = null)
        {
            foreach (var error in message.ValidationResult.Errors)
                notifications.Handle(new DomainNotification(error.PropertyName, error.ErrorMessage, group));
        }

        protected void NotifyErrors(string key, string message, string group = null, string result = null)
        {
            notifications.Handle(new DomainNotification(key, message, group,result));
        }
    }
}
