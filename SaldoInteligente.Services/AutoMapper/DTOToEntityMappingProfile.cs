using AutoMapper;
using SaldoInteligente.Domain.Entities;
using SaldoInteligente.Domain.Responses.BalanceCheckingStatementDTOs;

namespace SaldoInteligente.Services.AutoMapper
{
    public class DTOToEntityMappingProfile : Profile
    {
        public DTOToEntityMappingProfile()
        {
            #region BalanceCheckingStatement            
            CreateMap<AddLooseEntryDTO, BalanceCheckingStatementEntity>();
            CreateMap<AddNotLooseEntryDTO, BalanceCheckingStatementEntity>();
            CreateMap<ChangeDTO, BalanceCheckingStatementEntity>();
            #endregion
        }
    }
}

