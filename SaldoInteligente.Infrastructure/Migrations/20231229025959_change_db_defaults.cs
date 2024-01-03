using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SaldoInteligente.Infrastructure.Migrations
{
    public partial class change_db_defaults : Migration
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
                oldType: "tinyint");

            migrationBuilder.AlterColumn<bool>(
                name: "LooseEntry",
                table: "bank_balance_checking_statement",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: 1ul);

            migrationBuilder.AlterColumn<DateTime>(
                name: "InputDate",
                table: "bank_balance_checking_statement",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 21, 2, 59, 59, 623, DateTimeKind.Utc).AddTicks(6841),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.UpdateData(
                table: "bank_balance_checking_statement",
                keyColumn: "Description",
                keyValue: null,
                column: "Description",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "bank_balance_checking_statement",
                type: "varchar(2000)",
                maxLength: 2000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(2000)",
                oldMaxLength: 2000,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<sbyte>(
                name: "Status",
                table: "bank_balance_checking_statement",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "tinyint",
                oldDefaultValue: 1);

            migrationBuilder.AlterColumn<ulong>(
                name: "LooseEntry",
                table: "bank_balance_checking_statement",
                type: "bit",
                nullable: false,
                oldClrType: typeof(ulong),
                oldType: "bit",
                oldDefaultValue: 1ul);

            migrationBuilder.AlterColumn<DateTime>(
                name: "InputDate",
                table: "bank_balance_checking_statement",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2023, 12, 21, 2, 59, 59, 623, DateTimeKind.Utc).AddTicks(6841));

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "bank_balance_checking_statement",
                type: "varchar(2000)",
                maxLength: 2000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(2000)",
                oldMaxLength: 2000)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
