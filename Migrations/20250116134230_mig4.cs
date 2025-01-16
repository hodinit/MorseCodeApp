using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MorseCodeApp2.Migrations
{
    /// <inheritdoc />
    public partial class mig4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MorseDefaultConversion_User_UserID",
                table: "MorseDefaultConversion");

            migrationBuilder.DropIndex(
                name: "IX_MorseDefaultConversion_UserID",
                table: "MorseDefaultConversion");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "MorseDefaultConversion");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "MorseDefaultConversion",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MorseDefaultConversion_UserID",
                table: "MorseDefaultConversion",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_MorseDefaultConversion_User_UserID",
                table: "MorseDefaultConversion",
                column: "UserID",
                principalTable: "User",
                principalColumn: "ID");
        }
    }
}
