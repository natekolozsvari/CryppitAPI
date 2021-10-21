using Microsoft.EntityFrameworkCore.Migrations;

namespace CryppitBackend.Migrations
{
    public partial class SeedUserTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Balance", "Email", "JoinDate", "Name", "Password" },
                values: new object[] { "c784662e0c27497eb4337cb0b2109823", 1964.21, "john@doe.com", "Wednesday, September 15, 2021", "John Doe", "johndoe" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "c784662e0c27497eb4337cb0b2109823");
        }
    }
}
