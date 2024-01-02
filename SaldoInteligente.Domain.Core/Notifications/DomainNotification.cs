using MediatR;

namespace SaldoInteligente.Domain.Core.Notifications
{
    public class DomainNotification : INotification
    {
        public DomainNotification(string key, string value, string group = null, string result = null)
        {
            Key = key;
            Value = value;
            Group = group;
            Result = result;
        }

        public string Group { get; }
        public string Key { get; }
        public string Value { get; }
        public string Result { get; set; }
    }
}
