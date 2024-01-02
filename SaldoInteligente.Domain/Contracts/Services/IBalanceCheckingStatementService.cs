
using SaldoInteligente.Domain.Responses.BalanceCheckingStatementDTOs;
using SaldoInteligente.Domain.Responses.BalanceCheckingStatementResponses;

namespace SaldoInteligente.Domain.Contracts.Services
{

    public interface IBalanceCheckingStatementService
    {
        DefaultResponse AddLooseEntry(AddLooseEntryDTO dto);

        DefaultResponse AddNotLooseEntry(AddNotLooseEntryDTO dto);

        DefaultResponse Change(ChangeDTO dto);

        void CancelStatement(int id);

        List<ListResponse> FindStatements(FindRangeDateDTO dto);
    }    
}
