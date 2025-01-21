using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MorseCodeApp2.Migrations
{
    /// <inheritdoc />
    public partial class mig5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sentence_Date_DateID",
                table: "Sentence");

            migrationBuilder.DropTable(
                name: "Date");

            migrationBuilder.DropIndex(
                name: "IX_Sentence_DateID",
                table: "Sentence");

            migrationBuilder.DropColumn(
                name: "DateID",
                table: "Sentence");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Sentence",
                newName: "LastModifiedAt");

            migrationBuilder.AlterColumn<string>(
                name: "Character",
                table: "CustomMask",
                type: "nvarchar(1)",
                maxLength: 1,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastModifiedAt",
                table: "Sentence",
                newName: "CreatedAt");

            migrationBuilder.AddColumn<int>(
                name: "DateID",
                table: "Sentence",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Character",
                table: "CustomMask",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1)",
                oldMaxLength: 1);

            migrationBuilder.CreateTable(
                name: "Date",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Date", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sentence_DateID",
                table: "Sentence",
                column: "DateID");

            migrationBuilder.AddForeignKey(
                name: "FK_Sentence_Date_DateID",
                table: "Sentence",
                column: "DateID",
                principalTable: "Date",
                principalColumn: "ID");
        }
    }
}
