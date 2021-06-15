﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MinFritidAPI.Data;

namespace MinFritidAPI.Migrations
{
    [DbContext(typeof(MinFritidContext))]
    partial class MinFritidContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MinFritidAPI.Models.Admin", b =>
                {
                    b.Property<int>("AdminID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("AdminID");

                    b.ToTable("Admin");
                });

            modelBuilder.Entity("MinFritidAPI.Models.Aktivitet", b =>
                {
                    b.Property<int>("AktivitetID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Aktiv")
                        .HasColumnType("bit");

                    b.Property<int?>("AktivitetPostnummer")
                        .HasColumnType("int");

                    b.Property<string>("Beskrivelse")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Huskeliste")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MaxDeltagere")
                        .HasColumnType("int");

                    b.Property<int>("Pris")
                        .HasColumnType("int");

                    b.Property<DateTime>("SlutTidspunkt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartTidspunkt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Titel")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AktivitetID");

                    b.HasIndex("AktivitetPostnummer");

                    b.ToTable("Aktivitet");
                });

            modelBuilder.Entity("MinFritidAPI.Models.AktivitetBrugerTilmeldt", b =>
                {
                    b.Property<int>("AktivitetID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AktivitetID1")
                        .HasColumnType("int");

                    b.Property<int>("BrugerID")
                        .HasColumnType("int");

                    b.Property<int?>("Prioritet")
                        .HasColumnType("int");

                    b.HasKey("AktivitetID");

                    b.HasIndex("AktivitetID1");

                    b.HasIndex("BrugerID");

                    b.ToTable("AktivitetBrugerTilmeldt");
                });

            modelBuilder.Entity("MinFritidAPI.Models.Bruger", b =>
                {
                    b.Property<int>("BrugerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<bool>("Aktiv")
                        .HasColumnType("bit");

                    b.Property<int?>("BrugerPostnummer")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Efternavn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Foedselsdato")
                        .HasColumnType("Date");

                    b.Property<string>("Fornavn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Verificeret")
                        .HasColumnType("bit");

                    b.HasKey("BrugerID");

                    b.HasIndex("BrugerPostnummer");

                    b.ToTable("Bruger");
                });

            modelBuilder.Entity("MinFritidAPI.Models.By", b =>
                {
                    b.Property<int>("Postnummer")
                        .HasColumnType("int");

                    b.Property<string>("Bynavn")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Postnummer");

                    b.ToTable("By");
                });

            modelBuilder.Entity("MinFritidAPI.Models.Aktivitet", b =>
                {
                    b.HasOne("MinFritidAPI.Models.By", "By")
                        .WithMany()
                        .HasForeignKey("AktivitetPostnummer");

                    b.Navigation("By");
                });

            modelBuilder.Entity("MinFritidAPI.Models.AktivitetBrugerTilmeldt", b =>
                {
                    b.HasOne("MinFritidAPI.Models.Aktivitet", "Aktivitet")
                        .WithMany("AktivitetBrugerTilmeldt")
                        .HasForeignKey("AktivitetID1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MinFritidAPI.Models.Bruger", "Bruger")
                        .WithMany("AktivitetBrugerTilmeldt")
                        .HasForeignKey("BrugerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aktivitet");

                    b.Navigation("Bruger");
                });

            modelBuilder.Entity("MinFritidAPI.Models.Bruger", b =>
                {
                    b.HasOne("MinFritidAPI.Models.By", "By")
                        .WithMany()
                        .HasForeignKey("BrugerPostnummer");

                    b.Navigation("By");
                });

            modelBuilder.Entity("MinFritidAPI.Models.Aktivitet", b =>
                {
                    b.Navigation("AktivitetBrugerTilmeldt");
                });

            modelBuilder.Entity("MinFritidAPI.Models.Bruger", b =>
                {
                    b.Navigation("AktivitetBrugerTilmeldt");
                });
#pragma warning restore 612, 618
        }
    }
}