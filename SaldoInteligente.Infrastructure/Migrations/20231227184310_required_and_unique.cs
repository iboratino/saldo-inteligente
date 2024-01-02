using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SaldoInteligente.Infrastructure.Migrations
{
    public partial class required_and_unique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "bank_balance_checking_statement",
                type: "tinyint",
                nullable: false,
                defaultValue: 1,
                oldClrType: typeof(sbyte),
                oldType: "tinyint",
                oldDefaultValue: (sbyte)1);

            migrationBuilder.AlterColumn<DateTime>(
                name: "InputDate",
                table: "bank_balance_checking_statement",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 27, 18, 43, 10, 61, DateTimeKind.Utc).AddTicks(6809),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 12, 21, 23, 33, 25, 748, DateTimeKind.Utc).AddTicks(5230));

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "bank_balance_checking_statement",
                type: "varchar(80)",
                maxLength: 80,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(2000)",
                oldMaxLength: 2000)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_BalanceCheckingStatement_Description",
                table: "bank_balance_checking_statement",
                column: "Description",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_BalanceCheckingStatement_Description",
                table: "bank_balance_checking_statement");

            migrationBuilder.AlterColumn<sbyte>(
                name: "Status",
                table: "bank_balance_checking_statement",
                type: "tinyint",
                nullable: false,
                defaultValue: (sbyte)1,
                oldClrType: typeof(int),
                oldType: "tinyint",
                oldDefaultValue: 1);

            migrationBuilder.AlterColumn<DateTime>(
                name: "InputDate",
                table: "bank_balance_checking_statement",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 21, 23, 33, 25, 748, DateTimeKind.Utc).AddTicks(5230),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 12, 27, 18, 43, 10, 61, DateTimeKind.Utc).AddTicks(6809));

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "bank_balance_checking_statement",
                type: "varchar(2000)",
                maxLength: 2000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(80)",
                oldMaxLength: 80)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
