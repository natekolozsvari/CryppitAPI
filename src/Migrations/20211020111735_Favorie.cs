using Microsoft.EntityFrameworkCore.Migrations;

namespace CryppitBackend.Migrations
{
    public partial class Favorie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Daily_Crypto_DetailsId",
                table: "Daily");

            migrationBuilder.DropTable(
                name: "Favorites");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Crypto",
                table: "Crypto");

            migrationBuilder.RenameColumn(
                name: "DetailsId",
                table: "Daily",
                newName: "DetailsFavortieId");

            migrationBuilder.RenameIndex(
                name: "IX_Daily_DetailsId",
                table: "Daily",
                newName: "IX_Daily_DetailsFavortieId");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Crypto",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "FavortieId",
                table: "Crypto",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Crypto",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Crypto",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Crypto",
                table: "Crypto",
                column: "FavortieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Daily_Crypto_DetailsFavortieId",
                table: "Daily",
                column: "DetailsFavortieId",
                principalTable: "Crypto",
                principalColumn: "FavortieId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Daily_Crypto_DetailsFavortieId",
                table: "Daily");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Crypto",
                table: "Crypto");

            migrationBuilder.DropColumn(
                name: "FavortieId",
                table: "Crypto");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Crypto");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Crypto");

            migrationBuilder.RenameColumn(
                name: "DetailsFavortieId",
                table: "Daily",
                newName: "DetailsId");

            migrationBuilder.RenameIndex(
                name: "IX_Daily_DetailsFavortieId",
                table: "Daily",
                newName: "IX_Daily_DetailsId");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Crypto",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Crypto",
                table: "Crypto",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Favorites",
                columns: table => new
                {
                    Ath = table.Column<double>(type: "float", nullable: false),
                    Change = table.Column<double>(type: "float", nullable: false),
                    High24H = table.Column<double>(type: "float", nullable: false),
                    Id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Low24H = table.Column<double>(type: "float", nullable: false),
                    MarketCap = table.Column<double>(type: "float", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Symbol = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalVolume = table.Column<double>(type: "float", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Daily_Crypto_DetailsId",
                table: "Daily",
                column: "DetailsId",
                principalTable: "Crypto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
