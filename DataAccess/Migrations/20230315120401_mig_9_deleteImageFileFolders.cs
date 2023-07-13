using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class mig9deleteImageFileFolders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Files_Blogs_BlogId",
                table: "Files");

            migrationBuilder.DropForeignKey(
                name: "FK_Files_Portfolios_PortfolioId",
                table: "Files");

            migrationBuilder.DropForeignKey(
                name: "FK_Files_UserAbouts_UserAboutId",
                table: "Files");

            migrationBuilder.DropIndex(
                name: "IX_Files_BlogId",
                table: "Files");

            migrationBuilder.DropIndex(
                name: "IX_Files_PortfolioId",
                table: "Files");

            migrationBuilder.DropIndex(
                name: "IX_Files_UserAboutId",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "BlogId",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "PortfolioId",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "UserAboutId",
                table: "Files");

            migrationBuilder.AddColumn<int>(
                name: "OwnerId",
                table: "Files",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Files",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Files");

            migrationBuilder.AddColumn<int>(
                name: "BlogId",
                table: "Files",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Files",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "PortfolioId",
                table: "Files",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserAboutId",
                table: "Files",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Files_BlogId",
                table: "Files",
                column: "BlogId");

            migrationBuilder.CreateIndex(
                name: "IX_Files_PortfolioId",
                table: "Files",
                column: "PortfolioId");

            migrationBuilder.CreateIndex(
                name: "IX_Files_UserAboutId",
                table: "Files",
                column: "UserAboutId");

            migrationBuilder.AddForeignKey(
                name: "FK_Files_Blogs_BlogId",
                table: "Files",
                column: "BlogId",
                principalTable: "Blogs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Files_Portfolios_PortfolioId",
                table: "Files",
                column: "PortfolioId",
                principalTable: "Portfolios",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Files_UserAbouts_UserAboutId",
                table: "Files",
                column: "UserAboutId",
                principalTable: "UserAbouts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
