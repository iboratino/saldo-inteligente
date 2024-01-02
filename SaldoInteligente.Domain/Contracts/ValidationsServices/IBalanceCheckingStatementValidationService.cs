
using SaldoInteligente.Domain.Entities;

namespace SaldoInteligente.Domain.Contracts.ValidationsServices
{

    public interface IBalanceCheckingStatementValidationService
    {
        bool AbleToChange(BalanceCheckingStatementEntity entity);
    }    
}
