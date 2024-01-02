﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SaldoInteligente.Infrastructure.ORM;

#nullable disable

namespace SaldoInteligente.Infrastructure.Migrations
{
    [DbContext(typeof(BankAccountContext))]
    partial class BankAccountContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("SaldoInteligente.Domain.Entities.BalanceCheckingStatementEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CanceledAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("varchar(80)");

                    b.Property<DateTime>("InputDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasDefaultValue(new DateTime(2023, 12, 27, 18, 43, 10, 61, DateTimeKind.Utc).AddTicks(6809));

                    b.Property<ulong>("LooseEntry")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(1ul);

                    b.Property<int>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint")
                        .HasDefaultValue(1);

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Description" }, "IX_BalanceCheckingStatement_Description")
                        .IsUnique();

                    b.HasIndex(new[] { "InputDate" }, "IX_BalanceCheckingStatement_InputDate");

                    b.HasIndex(new[] { "LooseEntry" }, "IX_BalanceCheckingStatement_LooseEntry");

                    b.HasIndex(new[] { "Status" }, "IX_BalanceCheckingStatement_Status");

                    b.ToTable("bank_balance_checking_statement", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
