using AutoMapper;
using SaldoInteligente.Domain.Entities;
using SaldoInteligente.Domain.Responses.BalanceCheckingStatementResponses;

namespace SaldoInteligente.Services.AutoMapper
{
    public class EntityToResponseProfile : Profile
    {
        public EntityToResponseProfile()
        {
            #region BalanceCheckingStatement

            CreateMap<BalanceCheckingStatementEntity, DefaultResponse>()
                .ConvertUsing(x => new DefaultResponse
                {
                    Id = x.Id,
                    Description = x.Description,
                    InputDate = x.InputDate.ToLocalTime().ToString("dd/MM/yyyy"),
                    Value = x.Value.ToString("R$ #,##0.00"),
                    LooseEntry = x.LooseEntry,
                    Status = x.Status,
                });

            CreateMap<BalanceCheckingStatementEntity, ListResponse>();
            #endregion
        }
    }
}
