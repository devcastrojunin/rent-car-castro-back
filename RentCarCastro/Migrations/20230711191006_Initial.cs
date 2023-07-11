using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentCarCastro.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CPF = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CNPJ = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CNPJ", "CPF", "Email", "IsActive", "Name", "Password", "UserName" },
                values: new object[] { 35063373, "", "27904525801", "teste@teste.com", true, "Junior Castro", "admin@123", "junior.castro" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CNPJ", "CPF", "Email", "IsActive", "Name", "Password", "UserName" },
                values: new object[] { 942662159, "", "27904525801", "teste@teste3.com", false, "Maria Cecília", "admin@123", "maria.cecilia" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CNPJ", "CPF", "Email", "IsActive", "Name", "Password", "UserName" },
                values: new object[] { 2041960455, "", "27904525801", "teste@teste2.com", true, "José da Silva", "admin@123", "jose.silva" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
