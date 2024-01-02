using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SaldoInteligente.Domain.Entities;
using SaldoInteligente.Domain.Enum;

namespace SaldoInteligente.Infrastructure.ORM.Mapping
{
    public class BalanceCheckingStatementMapping : IEntityTypeConfiguration<BalanceCheckingStatementEntity>
    {
        public void Configure(EntityTypeBuilder<BalanceCheckingStatementEntity> builder)
        {
            builder.ToTable("bank_balance_checking_statement");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Description)
                   .HasMaxLength(80)
                   .IsRequired();

            builder.Property(x => x.Value)
                .HasColumnType("decimal(18, 2)")
                .IsRequired();

            builder.Property(x => x.InputDate)
                .HasDefaultValue(DateTime.UtcNow)
                .IsRequired();

            builder.Property(x => x.LooseEntry)
                .HasColumnType("bit")
                .HasDefaultValue(1)
                .IsRequired();

            builder.Property(x => x.Status)
                .HasColumnType("tinyint")
                .HasDefaultValue(BalanceCheckingStatementStatus.Valid)
                .IsRequired()
                .HasConversion<int>(
                   v => (int)v,
                   v => Enum.Parse<BalanceCheckingStatementStatus>(v.ToString()));


            builder.HasIndex(x => x.Description, "IX_BalanceCheckingStatement_Description")
                .IsUnique();
            builder.HasIndex(x => x.InputDate, "IX_BalanceCheckingStatement_InputDate");
            builder.HasIndex(x => x.LooseEntry, "IX_BalanceCheckingStatement_LooseEntry");
            builder.HasIndex(x => x.Status, "IX_BalanceCheckingStatement_Status");
        }
    }
}
