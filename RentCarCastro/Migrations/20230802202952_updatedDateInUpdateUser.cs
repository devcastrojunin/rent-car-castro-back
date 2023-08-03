using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentCarCastro.Migrations
{
    public partial class updatedDateInUpdateUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1946200859);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CNPJ", "CPF", "CreatedAt", "Email", "IsActive", "Name", "Password", "RoleId", "UpdatedAt", "UserName" },
                values: new object[] { 466602999, "", "12345678936", new DateTime(2023, 8, 2, 17, 29, 52, 196, DateTimeKind.Local).AddTicks(2156), "junior.castro@teste.com", true, "Junior Castro Admin", "admin@123", 1, new DateTime(2023, 8, 2, 17, 29, 52, 196, DateTimeKind.Local).AddTicks(2168), "junior.castro" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 466602999);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CNPJ", "CPF", "CreatedAt", "Email", "IsActive", "Name", "Password", "RoleId", "UpdatedAt", "UserName" },
                values: new object[] { 1946200859, "", "12345678936", new DateTime(2023, 8, 2, 9, 41, 55, 144, DateTimeKind.Local).AddTicks(4214), "junior.castro@teste.com", true, "Junior Castro Admin", "admin@123", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "junior.castro" });
        }
    }
}
