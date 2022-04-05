using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AuthApi.Database.Migrations
{
    public partial class M00 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    Password = table.Column<string>(type: "TEXT", nullable: true),
                    Role = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Password", "Role" },
                values: new object[] { new Guid("75e9c81e-2565-42df-b7f6-3032ab3de882"), "admin@pucminas.br", "$2a$11$PiDrdiHh/r6ZLfbKnbI10OHLEI59GZEId9glBxy.SbUMyPmhIKmUq", "Administrador" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Password", "Role" },
                values: new object[] { new Guid("16f907e9-39d4-451c-9399-85f2d01de644"), "jogador@pucminas.br", "$2a$11$FSGN1GPGS5ngbqer7oyD0uagPzhDrzUBNfhgR4WGXZC7X1jgiz4l6", "Jogador" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Password", "Role" },
                values: new object[] { new Guid("0ed9eded-1aa0-44e0-83de-e3c10aebaf83"), "capitao@pucminas.br", "$2a$11$dphfXwxi6e3SpCMuiLYSZuKWiSPMm2P1xDUbteeLgNhCOjGZJ.noK", "Capitao" });

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
