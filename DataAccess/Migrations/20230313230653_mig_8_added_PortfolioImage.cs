using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class mig8addedPortfolioImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Files_UserAboutId",
                table: "Files");

            migrationBuilder.AddColumn<int>(
                name: "PortfolioId",
                table: "Files",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Files_PortfolioId",
                table: "Files",
                column: "PortfolioId");

            migrationBuilder.CreateIndex(
                name: "IX_Files_UserAboutId",
                table: "Files",
                column: "UserAboutId");

            migrationBuilder.AddForeignKey(
                name: "FK_Files_Portfolios_PortfolioId",
                table: "Files",
                column: "PortfolioId",
                principalTable: "Portfolios",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Files_Portfolios_PortfolioId",
                table: "Files");

            migrationBuilder.DropIndex(
                name: "IX_Files_PortfolioId",
                table: "Files");

            migrationBuilder.DropIndex(
                name: "IX_Files_UserAboutId",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "PortfolioId",
                table: "Files");

            migrationBuilder.CreateIndex(
                name: "IX_Files_UserAboutId",
                table: "Files",
                column: "UserAboutId",
                unique: true,
                filter: "[UserAboutId] IS NOT NULL");
        }
    }
}
