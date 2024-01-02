using SaldoInteligente.Domain.Contracts.UtilsServices;
using SaldoInteligente.Domain.Contracts.ValidationsServices;
using SaldoInteligente.Domain.Entities;
using SaldoInteligente.Domain.Responses.BalanceCheckingStatementDTOs;

namespace SaldoInteligente.Services.Validations
{
    public class BalanceCheckingStatementValidationService : IBalanceCheckingStatementValidationService
    {
        private readonly IErrorService errorService;

        public BalanceCheckingStatementValidationService(IErrorService errorService)
        {
            this.errorService = errorService;
        }

        public bool AbleToChange(BalanceCheckingStatementEntity entity)
        {
            if (entity == null)
            {
                errorService.Errors("BalanceCheckingStatement", "Extrato não encontrado", "ValidationsService");
                return false;
            }
            else if (!entity.IsValid())
            {
                errorService.Errors("BalanceCheckingStatement", "Extrato está cancelado", "ValidationsService");
                return false;
            }

            return true;
        }
    }
}
