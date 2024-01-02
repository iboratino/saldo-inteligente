using Microsoft.AspNetCore.Mvc.ModelBinding;
using SaldoInteligente.Domain.Responses;

namespace SaldoInteligente.API.Utils
{
    public class ModelStateUtils
    {
        public static List<ModelErrorResponse> CreateValidationErrorResponse(ModelStateDictionary modelState)
        {
            var error = new List<ModelErrorResponse>();

            foreach (var item in modelState)
            {
                error.Add(new ModelErrorResponse
                {
                    Key = item.Key,
                    Erro = item.Value.Errors.FirstOrDefault().ErrorMessage.ToString()
                });
            }

            return error;

        }
    }
}
