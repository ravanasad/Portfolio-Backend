using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class mig5updatedAppUserUserAbout : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Abouts_UserABouts_UserAboutId",
                table: "Abouts");

            migrationBuilder.DropForeignKey(
                name: "FK_Histories_UserABouts_UserAboutId",
                table: "Histories");

            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_UserABouts_UserAboutId",
                table: "Jobs");

            migrationBuilder.DropForeignKey(
                name: "FK_Skills_UserABouts_UserAboutId",
                table: "Skills");

            migrationBuilder.DropForeignKey(
                name: "FK_SocialMedias_UserABouts_UserAboutId",
                table: "SocialMedias");

            migrationBuilder.DropIndex(
                name: "IX_SocialMedias_UserAboutId",
                table: "SocialMedias");

            migrationBuilder.DropIndex(
                name: "IX_Skills_UserAboutId",
                table: "Skills");

            migrationBuilder.DropIndex(
                name: "IX_Jobs_UserAboutId",
                table: "Jobs");

            migrationBuilder.DropIndex(
                name: "IX_Histories_UserAboutId",
                table: "Histories");

            migrationBuilder.DropIndex(
                name: "IX_Abouts_UserAboutId",
                table: "Abouts");

            migrationBuilder.DropColumn(
                name: "UserAboutId",
                table: "SocialMedias");

            migrationBuilder.DropColumn(
                name: "UserAboutId",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "UserAboutId",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "UserAboutId",
                table: "Histories");

            migrationBuilder.DropColumn(
                name: "UserAboutId",
                table: "Abouts");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserAboutId",
                table: "SocialMedias",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserAboutId",
                table: "Skills",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserAboutId",
                table: "Jobs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserAboutId",
                table: "Histories",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserAboutId",
                table: "Abouts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SocialMedias_UserAboutId",
                table: "SocialMedias",
                column: "UserAboutId");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_UserAboutId",
                table: "Skills",
                column: "UserAboutId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_UserAboutId",
                table: "Jobs",
                column: "UserAboutId");

            migrationBuilder.CreateIndex(
                name: "IX_Histories_UserAboutId",
                table: "Histories",
                column: "UserAboutId");

            migrationBuilder.CreateIndex(
                name: "IX_Abouts_UserAboutId",
                table: "Abouts",
                column: "UserAboutId");

            migrationBuilder.AddForeignKey(
                name: "FK_Abouts_UserABouts_UserAboutId",
                table: "Abouts",
                column: "UserAboutId",
                principalTable: "UserABouts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Histories_UserABouts_UserAboutId",
                table: "Histories",
                column: "UserAboutId",
                principalTable: "UserABouts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_UserABouts_UserAboutId",
                table: "Jobs",
                column: "UserAboutId",
                principalTable: "UserABouts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_UserABouts_UserAboutId",
                table: "Skills",
                column: "UserAboutId",
                principalTable: "UserABouts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SocialMedias_UserABouts_UserAboutId",
                table: "SocialMedias",
                column: "UserAboutId",
                principalTable: "UserABouts",
                principalColumn: "Id");
        }
    }
}
