using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MinFritidAPI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aktivitets",
                columns: table => new
                {
                    AktivitetID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Titel = table.Column<string>(nullable: true),
                    Beskrivelse = table.Column<string>(nullable: true),
                    Huskeliste = table.Column<string>(nullable: true),
                    Pris = table.Column<int>(nullable: false),
                    MaxDeltagere = table.Column<int>(nullable: false),
                    StartTidspunkt = table.Column<DateTime>(nullable: false),
                    SlutTidspunkt = table.Column<DateTime>(nullable: false),
                    By = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aktivitets", x => x.AktivitetID);
                });

            migrationBuilder.CreateTable(
                name: "Brugers",
                columns: table => new
                {
                    BrugerID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Fornavn = table.Column<string>(nullable: true),
                    Efternavn = table.Column<string>(nullable: true),
                    Foedselsdato = table.Column<DateTime>(nullable: false),
                    By = table.Column<int>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Verificeret = table.Column<bool>(nullable: false),
                    Aktiv = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brugers", x => x.BrugerID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aktivitets");

            migrationBuilder.DropTable(
                name: "Brugers");
        }
    }
}
