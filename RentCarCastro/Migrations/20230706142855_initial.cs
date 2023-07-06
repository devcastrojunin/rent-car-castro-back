using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentCarCastro.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CPF = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CNPJ = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
