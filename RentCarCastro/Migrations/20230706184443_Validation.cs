using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentCarCastro.Migrations
{
    public partial class Validation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("041b9a79-e4b1-4e17-b864-506459f97cab"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("cd1031dc-4db8-40cd-a679-9bac0ae276a5"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d7574dd4-8a18-4e48-9c73-80be10adc24f"));

            migrationBuilder.AlterColumn<string>(
                name: "CPF",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CNPJ",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CNPJ", "CPF", "Email", "IsActive", "Name", "Password" },
                values: new object[] { new Guid("79f2df44-e8f4-421d-be4a-c6898520903a"), "", "27904525801", "teste@teste.com", true, "Junior Castro", "admin@123" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CNPJ", "CPF", "Email", "IsActive", "Name", "Password" },
                values: new object[] { new Guid("84a0e111-f838-4aa7-920e-2cbe3a2111b0"), "", "27904525801", "teste@teste3.com", false, "Maria Cecília", "admin@123" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CNPJ", "CPF", "Email", "IsActive", "Name", "Password" },
                values: new object[] { new Guid("d008051e-7546-48f3-bc3e-494e85fe981f"), "", "27904525801", "teste@teste2.com", true, "José da Silva", "admin@123" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("79f2df44-e8f4-421d-be4a-c6898520903a"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("84a0e111-f838-4aa7-920e-2cbe3a2111b0"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d008051e-7546-48f3-bc3e-494e85fe981f"));

            migrationBuilder.AlterColumn<string>(
                name: "CPF",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CNPJ",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CNPJ", "CPF", "Email", "IsActive", "Name", "Password" },
                values: new object[] { new Guid("041b9a79-e4b1-4e17-b864-506459f97cab"), "", "27904525801", "teste@teste2.com", true, "José da Silva", "admin@123" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CNPJ", "CPF", "Email", "IsActive", "Name", "Password" },
                values: new object[] { new Guid("cd1031dc-4db8-40cd-a679-9bac0ae276a5"), "", "27904525801", "teste@teste.com", true, "Junior Castro", "admin@123" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CNPJ", "CPF", "Email", "IsActive", "Name", "Password" },
                values: new object[] { new Guid("d7574dd4-8a18-4e48-9c73-80be10adc24f"), "", "27904525801", "teste@teste3.com", false, "Maria Cecília", "admin@123" });
        }
    }
}
