using SaldoInteligente.Domain.Enum;

namespace SaldoInteligente.Domain.Entities
{
    public class BalanceCheckingStatementEntity
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime InputDate { get; set; }
        public decimal Value { get; set; }
        public bool LooseEntry { get; set; }
        public BalanceCheckingStatementStatus Status { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime CanceledAt { get; set; }

        public bool IsValid()
        {
            return this.Status == BalanceCheckingStatementStatus.Valid;
        }
    }
}