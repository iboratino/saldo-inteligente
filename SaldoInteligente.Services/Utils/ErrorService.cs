using MediatR;
using Newtonsoft.Json;
using SaldoInteligente.Domain.Contracts.UtilsServices;
using SaldoInteligente.Domain.Core.Commands;
using SaldoInteligente.Domain.Core.Notifications;

namespace SaldoInteligente.Services.Utils
{
    public class ErrorService : CommandHandler, IErrorService
    {

        public ErrorService(INotificationHandler<DomainNotification> notifications) : base(notifications)
        {

        }

        public void Errors(string key, string message, string group, HttpResponseMessage result = null)
        {
            NotifyErrors(
                $"{key}",
                $"{message}",
                $"{group}",
                $"{JsonConvert.DeserializeObject<object>(result.Content.ReadAsStringAsync().Result)}");
        }

        public void Errors(string key, string message, string group, object body, Exception ex)
        {
            NotifyErrors(
                $"{key}",
                $"{JsonConvert.SerializeObject(ex)}",
                $"{group}",
                $"{JsonConvert.SerializeObject(body)}");
        }

        public void Errors(string key, string message, string group)
        {
            NotifyErrors(
                $"{key}",
                $"{message}",
                $"{group}",
                $"");
        }
    }
}
