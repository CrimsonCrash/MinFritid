using Microsoft.EntityFrameworkCore.Migrations;

namespace MinFritidAPI.Migrations
{
    public partial class test2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Aktivitet_BrugerID",
                table: "Aktivitet",
                column: "BrugerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Aktivitet_Bruger_BrugerID",
                table: "Aktivitet",
                column: "BrugerID",
                principalTable: "Bruger",
                principalColumn: "BrugerID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aktivitet_Bruger_BrugerID",
                table: "Aktivitet");

            migrationBuilder.DropIndex(
                name: "IX_Aktivitet_BrugerID",
                table: "Aktivitet");
        }
    }
}
