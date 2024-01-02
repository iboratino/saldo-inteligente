using AutoMapper;
using Humanizer;
using SaldoInteligente.Domain.Contracts.Repositories;
using SaldoInteligente.Domain.Contracts.Services;
using SaldoInteligente.Domain.Contracts.UtilsServices;
using SaldoInteligente.Domain.Contracts.ValidationsServices;
using SaldoInteligente.Domain.Entities;
using SaldoInteligente.Domain.Responses.BalanceCheckingStatementDTOs;
using SaldoInteligente.Domain.Responses.BalanceCheckingStatementResponses;

namespace SaldoInteligente.Services.Service
{
    public class BalanceCheckingStatementService : IBalanceCheckingStatementService
    {
        private readonly IMapper mapper;
        private readonly IErrorService errorService;
        private readonly IBalanceCheckingStatementRepository statementRepository;
        private readonly IBalanceCheckingStatementValidationService validations;

        public BalanceCheckingStatementService(IMapper mapper, IErrorService errorService, IBalanceCheckingStatementRepository balanceCheckingStatementRepository, IBalanceCheckingStatementValidationService validations)
        {
            this.statementRepository = balanceCheckingStatementRepository;
            this.mapper = mapper;
            this.errorService = errorService;
            this.validations = validations;
        }

        public DefaultResponse AddLooseEntry(AddLooseEntryDTO dto)
        {
            var entity = mapper.Map<BalanceCheckingStatementEntity>(dto);

            entity.LooseEntry = true;
            entity.CreatedAt = DateTime.UtcNow;

            var inserted = statementRepository.Insert(entity);

            return mapper.Map<DefaultResponse>(inserted);
        }

        public DefaultResponse AddNotLooseEntry(AddNotLooseEntryDTO dto)
        {
            var entity = mapper.Map<BalanceCheckingStatementEntity>(dto);

            entity.LooseEntry = false;
            entity.CreatedAt = DateTime.UtcNow;

            var inserted = statementRepository.Insert(entity);

            return mapper.Map<DefaultResponse>(inserted);
        }

        public DefaultResponse Change(ChangeDTO dto)
        {
            try
            {
                var statementCheck = statementRepository.Find(dto.Id);

                #region Validations
                if (!validations.AbleToChange(statementCheck))
                {
                    return null;
                }
                #endregion

                statementCheck = mapper.Map(dto, statementCheck);

                statementCheck.UpdatedAt = DateTime.UtcNow;

                var updated = statementRepository.Update(statementCheck);

                return mapper.Map<DefaultResponse>(updated);
            }
            catch (Exception ex)
            {
                errorService.Errors("ChangeStatement", ex.Message, "Service");
                return null;
            }            
        }

        public void CancelStatement(int id)
        {
            var entity = statementRepository.Find(id);

            #region Validations
            if (!validations.AbleToChange(entity))
            {
                return;
            }
            #endregion

            entity.Status = Domain.Enum.BalanceCheckingStatementStatus.Canceled;
            entity.CanceledAt = DateTime.UtcNow;

            statementRepository.Update(entity);
        }        

        public List<ListResponse> FindStatements(FindRangeDateDTO dto)
        {
            var statements = statementRepository.FindRangeDate(dto);

            return mapper.Map<List<ListResponse>>(statements);
        }
    }
}
