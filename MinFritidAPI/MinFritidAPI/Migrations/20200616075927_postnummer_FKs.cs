using Microsoft.EntityFrameworkCore.Migrations;

namespace MinFritidAPI.Migrations
{
    public partial class postnummer_FKs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PostNummer",
                table: "Bruger");

            migrationBuilder.DropColumn(
                name: "PostNummer",
                table: "Aktivitet");

            migrationBuilder.RenameColumn(
                name: "PostNummer",
                table: "By",
                newName: "Postnummer");

            migrationBuilder.AddColumn<int>(
                name: "BrugerPostnummer",
                table: "Bruger",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AktivitetPostnummer",
                table: "Aktivitet",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bruger_BrugerPostnummer",
                table: "Bruger",
                column: "BrugerPostnummer");

            migrationBuilder.CreateIndex(
                name: "IX_Aktivitet_AktivitetPostnummer",
                table: "Aktivitet",
                column: "AktivitetPostnummer");

            migrationBuilder.AddForeignKey(
                name: "FK_Aktivitet_By_AktivitetPostnummer",
                table: "Aktivitet",
                column: "AktivitetPostnummer",
                principalTable: "By",
                principalColumn: "Postnummer",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Bruger_By_BrugerPostnummer",
                table: "Bruger",
                column: "BrugerPostnummer",
                principalTable: "By",
                principalColumn: "Postnummer",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aktivitet_By_AktivitetPostnummer",
                table: "Aktivitet");

            migrationBuilder.DropForeignKey(
                name: "FK_Bruger_By_BrugerPostnummer",
                table: "Bruger");

            migrationBuilder.DropIndex(
                name: "IX_Bruger_BrugerPostnummer",
                table: "Bruger");

            migrationBuilder.DropIndex(
                name: "IX_Aktivitet_AktivitetPostnummer",
                table: "Aktivitet");

            migrationBuilder.DropColumn(
                name: "BrugerPostnummer",
                table: "Bruger");

            migrationBuilder.DropColumn(
                name: "AktivitetPostnummer",
                table: "Aktivitet");

            migrationBuilder.RenameColumn(
                name: "Postnummer",
                table: "By",
                newName: "PostNummer");

            migrationBuilder.AddColumn<int>(
                name: "PostNummer",
                table: "Bruger",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PostNummer",
                table: "Aktivitet",
                nullable: false,
                defaultValue: 0);
        }
    }
}
