﻿using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MinFritidAPI.Migrations
{
    public partial class recreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    AdminID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.AdminID);
                });

            migrationBuilder.CreateTable(
                name: "By",
                columns: table => new
                {
                    Postnummer = table.Column<int>(nullable: false),
                    Bynavn = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_By", x => x.Postnummer);
                });

            migrationBuilder.CreateTable(
                name: "Aktivitet",
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
                    AktivitetPostnummer = table.Column<int>(nullable: true),
                    Aktiv = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aktivitet", x => x.AktivitetID);
                    table.ForeignKey(
                        name: "FK_Aktivitet_By_AktivitetPostnummer",
                        column: x => x.AktivitetPostnummer,
                        principalTable: "By",
                        principalColumn: "Postnummer",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Bruger",
                columns: table => new
                {
                    BrugerID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Fornavn = table.Column<string>(nullable: true),
                    Efternavn = table.Column<string>(nullable: true),
                    Foedselsdato = table.Column<DateTime>(type: "Date", nullable: false),
                    BrugerPostnummer = table.Column<int>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Verificeret = table.Column<bool>(nullable: false),
                    Aktiv = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bruger", x => x.BrugerID);
                    table.ForeignKey(
                        name: "FK_Bruger_By_BrugerPostnummer",
                        column: x => x.BrugerPostnummer,
                        principalTable: "By",
                        principalColumn: "Postnummer",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AktivitetBrugerTilmeldt",
                columns: table => new
                {
                    AktivitetID = table.Column<int>(nullable: false),
                    BrugerID = table.Column<int>(nullable: false),
                    Prioritet = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AktivitetBrugerTilmeldt", x => new { x.AktivitetID, x.BrugerID });
                    table.ForeignKey(
                        name: "FK_AktivitetBrugerTilmeldt_Aktivitet_AktivitetID",
                        column: x => x.AktivitetID,
                        principalTable: "Aktivitet",
                        principalColumn: "AktivitetID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AktivitetBrugerTilmeldt_Bruger_BrugerID",
                        column: x => x.BrugerID,
                        principalTable: "Bruger",
                        principalColumn: "BrugerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aktivitet_AktivitetPostnummer",
                table: "Aktivitet",
                column: "AktivitetPostnummer");

            migrationBuilder.CreateIndex(
                name: "IX_AktivitetBrugerTilmeldt_BrugerID",
                table: "AktivitetBrugerTilmeldt",
                column: "BrugerID");

            migrationBuilder.CreateIndex(
                name: "IX_Bruger_BrugerPostnummer",
                table: "Bruger",
                column: "BrugerPostnummer");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "AktivitetBrugerTilmeldt");

            migrationBuilder.DropTable(
                name: "Aktivitet");

            migrationBuilder.DropTable(
                name: "Bruger");

            migrationBuilder.DropTable(
                name: "By");
        }
    }
}
