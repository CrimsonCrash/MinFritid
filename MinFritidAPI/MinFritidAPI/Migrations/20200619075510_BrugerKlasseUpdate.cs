using Microsoft.EntityFrameworkCore.Migrations;

namespace MinFritidAPI.Migrations
{
    public partial class BrugerKlasseUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bruger_By_BrugerPostnummer",
                table: "Bruger");

            migrationBuilder.AlterColumn<int>(
                name: "BrugerPostnummer",
                table: "Bruger",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Bruger_By_BrugerPostnummer",
                table: "Bruger",
                column: "BrugerPostnummer",
                principalTable: "By",
                principalColumn: "Postnummer",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bruger_By_BrugerPostnummer",
                table: "Bruger");

            migrationBuilder.AlterColumn<int>(
                name: "BrugerPostnummer",
                table: "Bruger",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Bruger_By_BrugerPostnummer",
                table: "Bruger",
                column: "BrugerPostnummer",
                principalTable: "By",
                principalColumn: "Postnummer",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
