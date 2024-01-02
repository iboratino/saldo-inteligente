namespace SaldoInteligente.Domain.Contracts.UtilsServices
{
    public interface IErrorService
    {
        void Errors(string key, string message, string group, HttpResponseMessage result);
        //void Errors(string key, string message, string group, IRestResponse result);
        void Errors(string key, string message, string group, object body, Exception ex);
        void Errors(string key, string message, string group);
    }
}
