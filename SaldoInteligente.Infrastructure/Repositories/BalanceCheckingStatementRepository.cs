using Microsoft.EntityFrameworkCore;
using SaldoInteligente.Domain.Contracts.Repositories;
using SaldoInteligente.Domain.Entities;
using SaldoInteligente.Domain.Responses.BalanceCheckingStatementDTOs;
using SaldoInteligente.Infrastructure.ORM;

namespace SaldoInteligente.Infrastructure.Repositories
{

    public class BalanceCheckingStatementRepository : Repository<BankAccountContext, BalanceCheckingStatementEntity>, IBalanceCheckingStatementRepository
    {

        public BalanceCheckingStatementRepository(BankAccountContext context) : base(context)
        {

        }

        public List<BalanceCheckingStatementEntity> FindRangeDate(FindRangeDateDTO dto)
        {
            IQueryable<BalanceCheckingStatementEntity> query = _context.BalanceCheckingStatement;
            if (dto?.InitialDate == DateTime.MinValue && dto?.FinalDate == DateTime.MinValue)
            {
                query = query.Where(s => s.InputDate >= DateTime.Today.AddDays(-2));
            }
            else if (dto?.InitialDate == null && dto?.FinalDate == null)
            {
                query = query.Where(s => s.InputDate >= DateTime.Today.AddDays(-2));
            }
            else if (dto?.InitialDate != DateTime.MinValue && dto?.FinalDate != DateTime.MinValue)
            {
                query = query.Where(s => s.InputDate >= dto.InitialDate.Date && s.InputDate <= dto.FinalDate.Date.AddDays(1).AddTicks(-1));
            }
            else if (dto?.InitialDate != DateTime.MinValue)
            {
                query = query.Where(s => s.InputDate >= dto.InitialDate);
            }
            else if (dto?.FinalDate != DateTime.MinValue)
            {
                query = query.Where(s => s.InputDate <= dto.FinalDate);
            }

            return query.AsNoTracking().ToList();
        }
    }    
}
