using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NewsWebApp.Migrations
{
    public partial class EnumerationsForRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false, defaultValue: 2),
                    Status = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    IsActivate = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    NewId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.NewId);
                    table.ForeignKey(
                        name: "FK_News_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserId", "Email", "Ime", "Password", "Prezime" },
                values: new object[] { 1, "bradpit@s", "Brad", "pit123", "Pit" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserId", "Email", "Ime", "Password", "Prezime" },
                values: new object[] { 2, "hamzabeg@t", "Hamza", "hamza123", "Beganovic" });

            migrationBuilder.InsertData(
                table: "News",
                columns: new[] { "NewId", "Content", "Description", "Title", "UserId" },
                values: new object[] { 1, "I learn .Net core", "Student of Politehnicki fakultet in Zenica", "I am Hamza", 1 });

            migrationBuilder.InsertData(
                table: "News",
                columns: new[] { "NewId", "Content", "Description", "Title", "UserId" },
                values: new object[] { 2, "I will also try to learn Angular", "With great story", "I am junior developer", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_News_UserId",
                table: "News",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "News");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
