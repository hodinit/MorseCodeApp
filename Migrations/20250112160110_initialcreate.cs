using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MorseCodeApp2.Migrations
{
    /// <inheritdoc />
    public partial class initialcreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Admin = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CustomMask",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Character = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomEquivalent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomMask", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CustomMask_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "MorseDefaultConversion",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Character = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MorseEquivalent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MorseDefaultConversion", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MorseDefaultConversion_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Sentence",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Input = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Output = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserID = table.Column<int>(type: "int", nullable: true),
                    MorseDefaultConversionID = table.Column<int>(type: "int", nullable: true),
                    CustomMaskID = table.Column<int>(type: "int", nullable: true),
                    DateID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sentence", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Sentence_CustomMask_CustomMaskID",
                        column: x => x.CustomMaskID,
                        principalTable: "CustomMask",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Sentence_Date_DateID",
                        column: x => x.DateID,
                        principalTable: "Date",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Sentence_MorseDefaultConversion_MorseDefaultConversionID",
                        column: x => x.MorseDefaultConversionID,
                        principalTable: "MorseDefaultConversion",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Sentence_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomMask_UserID",
                table: "CustomMask",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_MorseDefaultConversion_UserID",
                table: "MorseDefaultConversion",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Sentence_CustomMaskID",
                table: "Sentence",
                column: "CustomMaskID");

            migrationBuilder.CreateIndex(
                name: "IX_Sentence_DateID",
                table: "Sentence",
                column: "DateID");

            migrationBuilder.CreateIndex(
                name: "IX_Sentence_MorseDefaultConversionID",
                table: "Sentence",
                column: "MorseDefaultConversionID");

            migrationBuilder.CreateIndex(
                name: "IX_Sentence_UserID",
                table: "Sentence",
                column: "UserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sentence");

            migrationBuilder.DropTable(
                name: "CustomMask");

            migrationBuilder.DropTable(
                name: "Date");

            migrationBuilder.DropTable(
                name: "MorseDefaultConversion");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
