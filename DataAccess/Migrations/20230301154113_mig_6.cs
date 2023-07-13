using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class mig6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserABouts_AspNetUsers_AppUserId",
                table: "UserABouts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserABouts",
                table: "UserABouts");

            migrationBuilder.DropIndex(
                name: "IX_UserABouts_AppUserId",
                table: "UserABouts");

            migrationBuilder.RenameTable(
                name: "UserABouts",
                newName: "UserAbouts");

            migrationBuilder.AddColumn<int>(
                name: "AppUserId",
                table: "Contacts",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserAbouts",
                table: "UserAbouts",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Files",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserAboutId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Files_UserAbouts_UserAboutId",
                        column: x => x.UserAboutId,
                        principalTable: "UserAbouts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserAbouts_AppUserId",
                table: "UserAbouts",
                column: "AppUserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_AppUserId",
                table: "Contacts",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Files_UserAboutId",
                table: "Files",
                column: "UserAboutId",
                unique: true,
                filter: "[UserAboutId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_AspNetUsers_AppUserId",
                table: "Contacts",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAbouts_AspNetUsers_AppUserId",
                table: "UserAbouts",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_AspNetUsers_AppUserId",
                table: "Contacts");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAbouts_AspNetUsers_AppUserId",
                table: "UserAbouts");

            migrationBuilder.DropTable(
                name: "Files");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserAbouts",
                table: "UserAbouts");

            migrationBuilder.DropIndex(
                name: "IX_UserAbouts_AppUserId",
                table: "UserAbouts");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_AppUserId",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Contacts");

            migrationBuilder.RenameTable(
                name: "UserAbouts",
                newName: "UserABouts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserABouts",
                table: "UserABouts",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserABouts_AppUserId",
                table: "UserABouts",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserABouts_AspNetUsers_AppUserId",
                table: "UserABouts",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
