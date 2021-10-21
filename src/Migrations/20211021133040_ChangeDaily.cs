using Microsoft.EntityFrameworkCore.Migrations;

namespace CryppitBackend.Migrations
{
    public partial class ChangeDaily : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Daily_Crypto_DetailsId",
            //    table: "Daily");

            //migrationBuilder.DropTable(
            //    name: "Crypto");

            migrationBuilder.DropIndex(
                name: "IX_Daily_DetailsId",
                table: "Daily");

            migrationBuilder.DropColumn(
                name: "DetailsId",
                table: "Daily");

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "Daily",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "Daily");

            migrationBuilder.AddColumn<string>(
                name: "DetailsId",
                table: "Daily",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Crypto",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Ath = table.Column<double>(type: "float", nullable: false),
                    Change = table.Column<double>(type: "float", nullable: false),
                    High24H = table.Column<double>(type: "float", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Low24H = table.Column<double>(type: "float", nullable: false),
                    MarketCap = table.Column<double>(type: "float", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Symbol = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalVolume = table.Column<double>(type: "float", nullable: false),
                    Value = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Crypto", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Daily_DetailsId",
                table: "Daily",
                column: "DetailsId");

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
