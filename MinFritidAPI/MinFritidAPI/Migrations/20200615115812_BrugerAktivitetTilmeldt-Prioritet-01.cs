using Microsoft.EntityFrameworkCore.Migrations;

namespace MinFritidAPI.Migrations
{
    public partial class BrugerAktivitetTilmeldtPrioritet01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BrugerID",
                table: "Aktivitet");

            migrationBuilder.AddColumn<int>(
                name: "Prioritet",
                table: "AktivitetBrugerTilmeldt",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Prioritet",
                table: "AktivitetBrugerTilmeldt");

            migrationBuilder.AddColumn<int>(
                name: "BrugerID",
                table: "Aktivitet",
                nullable: false,
                defaultValue: 0);
        }
    }
}
