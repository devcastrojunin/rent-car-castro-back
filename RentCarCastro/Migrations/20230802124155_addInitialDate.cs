using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentCarCastro.Migrations
{
    public partial class addInitialDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 131730196);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CNPJ", "CPF", "CreatedAt", "Email", "IsActive", "Name", "Password", "RoleId", "UpdatedAt", "UserName" },
                values: new object[] { 1946200859, "", "12345678936", new DateTime(2023, 8, 2, 9, 41, 55, 144, DateTimeKind.Local).AddTicks(4214), "junior.castro@teste.com", true, "Junior Castro Admin", "admin@123", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "junior.castro" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1946200859);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CNPJ", "CPF", "CreatedAt", "Email", "IsActive", "Name", "Password", "RoleId", "UpdatedAt", "UserName" },
                values: new object[] { 131730196, "", "12345678936", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "junior.castro@teste.com", true, "Junior Castro Admin", "admin@123", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "junior.castro" });
        }
    }
}
