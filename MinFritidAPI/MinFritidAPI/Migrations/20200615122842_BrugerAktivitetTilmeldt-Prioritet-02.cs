using Microsoft.EntityFrameworkCore.Migrations;

namespace MinFritidAPI.Migrations
{
    public partial class BrugerAktivitetTilmeldtPrioritet02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Prioritet",
                table: "AktivitetBrugerTilmeldt",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Prioritet",
                table: "AktivitetBrugerTilmeldt",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
