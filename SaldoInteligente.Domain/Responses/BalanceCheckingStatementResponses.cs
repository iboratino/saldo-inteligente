using SaldoInteligente.Domain.Entities;
using SaldoInteligente.Domain.Enum;

namespace SaldoInteligente.Domain.Responses.BalanceCheckingStatementResponses
{
    public class DefaultResponse
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string InputDate { get; set; }
        public string Value { get; set; }
        public bool LooseEntry { get; set; }
        public BalanceCheckingStatementStatus Status { get; set; }
    }
    public class CancelResponse : DefaultResponse {}
    public class ListResponse : DefaultResponse {}
}
