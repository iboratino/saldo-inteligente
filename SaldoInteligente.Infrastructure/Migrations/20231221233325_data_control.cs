using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SaldoInteligente.Infrastructure.Migrations
{
    public partial class data_control : Migration
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
                defaultValue: new DateTime(2023, 12, 21, 23, 33, 25, 748, DateTimeKind.Utc).AddTicks(5230),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 12, 21, 2, 59, 59, 623, DateTimeKind.Utc).AddTicks(6841));

            migrationBuilder.AddColumn<DateTime>(
                name: "CanceledAt",
                table: "bank_balance_checking_statement",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "bank_balance_checking_statement",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "bank_balance_checking_statement",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CanceledAt",
                table: "bank_balance_checking_statement");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "bank_balance_checking_statement");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
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
                defaultValue: new DateTime(2023, 12, 21, 2, 59, 59, 623, DateTimeKind.Utc).AddTicks(6841),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 12, 21, 23, 33, 25, 748, DateTimeKind.Utc).AddTicks(5230));
        }
    }
}
