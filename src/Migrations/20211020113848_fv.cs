using Microsoft.EntityFrameworkCore.Migrations;

namespace CryppitBackend.Migrations
{
    public partial class fv : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Favorties",
                newName: "Favorites");

            migrationBuilder.DropForeignKey(
                name: "FK_Daily_Crypto_DetailsFavortieId",
                table: "Daily");

            migrationBuilder.DropIndex(
                name: "IX_Daily_DetailsFavortieId",
                table: "Daily");


            migrationBuilder.DropColumn(
                name: "DetailsFavortieId",
                table: "Daily");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Favorites");

            migrationBuilder.AddColumn<string>(
                name: "Details",
                table: "Daily",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Favorites",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
     name: "Favorties",
     newName: "Favorites");

            migrationBuilder.DropForeignKey(
                name: "FK_Daily_Crypto_DetailsFavortieId",
                table: "Daily");

            migrationBuilder.DropIndex(
                name: "IX_Daily_DetailsFavortieId",
                table: "Daily");


            migrationBuilder.DropColumn(
                name: "DetailsFavortieId",
                table: "Daily");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Favorites");

            migrationBuilder.AddColumn<string>(
                name: "Details",
                table: "Daily",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Favorites",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

        }
    }
}
