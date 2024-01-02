using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SaldoInteligente.Infrastructure.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "bank_balance_checking_statement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(type: "varchar(2000)", maxLength: 2000, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    InputDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Value = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LooseEntry = table.Column<ulong>(type: "bit", nullable: false),
                    Status = table.Column<int>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bank_balance_checking_statement", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_BalanceCheckingStatement_InputDate",
                table: "bank_balance_checking_statement",
                column: "InputDate");

            migrationBuilder.CreateIndex(
                name: "IX_BalanceCheckingStatement_LooseEntry",
                table: "bank_balance_checking_statement",
                column: "LooseEntry");

            migrationBuilder.CreateIndex(
                name: "IX_BalanceCheckingStatement_Status",
                table: "bank_balance_checking_statement",
                column: "Status");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bank_balance_checking_statement");
        }
    }
}
