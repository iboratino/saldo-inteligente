﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SaldoInteligente.Infrastructure.ORM;

#nullable disable

namespace SaldoInteligente.Infrastructure.Migrations
{
    [DbContext(typeof(BankAccountContext))]
    [Migration("20231219230631_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<string>("Description")
                        .HasMaxLength(2000)
                        .HasColumnType("varchar(2000)");

                    b.Property<DateTime>("InputDate")
                        .HasColumnType("datetime(6)");

                    b.Property<ulong>("LooseEntry")
                        .HasColumnType("bit");

                    b.Property<int>("Status")
                        .HasColumnType("tinyint");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "InputDate" }, "IX_BalanceCheckingStatement_InputDate");

                    b.HasIndex(new[] { "LooseEntry" }, "IX_BalanceCheckingStatement_LooseEntry");

                    b.HasIndex(new[] { "Status" }, "IX_BalanceCheckingStatement_Status");

                    b.ToTable("bank_balance_checking_statement", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}