
using SaldoInteligente.Domain.Entities;
using SaldoInteligente.Domain.Responses.BalanceCheckingStatementDTOs;

namespace SaldoInteligente.Domain.Contracts.Repositories
{
    public interface IBalanceCheckingStatementRepository : IRepository<BalanceCheckingStatementEntity>
    {
        List<BalanceCheckingStatementEntity> FindRangeDate(FindRangeDateDTO dto);
    }    
}
