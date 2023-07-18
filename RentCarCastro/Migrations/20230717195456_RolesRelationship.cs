using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentCarCastro.Migrations
{
    public partial class RolesRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1120623263);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1189301055);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1532583414);

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Roles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Roles_UserId",
                table: "Roles",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CNPJ", "CPF", "Email", "IsActive", "Name", "Password", "UserName" },
                values: new object[] { 1120623263, "", "27904525801", "teste@teste3.com", false, "Maria Cecília", "admin@123", "maria.cecilia" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CNPJ", "CPF", "Email", "IsActive", "Name", "Password", "UserName" },
                values: new object[] { 1189301055, "", "27904525801", "teste@teste.com", true, "Junior Castro", "admin@123", "junior.castro" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CNPJ", "CPF", "Email", "IsActive", "Name", "Password", "UserName" },
                values: new object[] { 1532583414, "", "27904525801", "teste@teste2.com", true, "José da Silva", "admin@123", "jose.silva" });
        }
    }
}
