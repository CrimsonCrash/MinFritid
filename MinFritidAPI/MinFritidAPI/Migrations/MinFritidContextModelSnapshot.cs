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
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MinFritidAPI.Models.Aktivitet", b =>
                {
                    b.Property<int>("AktivitetID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Beskrivelse");

                    b.Property<int>("By");

                    b.Property<string>("Huskeliste");

                    b.Property<int>("MaxDeltagere");

                    b.Property<int>("Pris");

                    b.Property<DateTime>("SlutTidspunkt");

                    b.Property<DateTime>("StartTidspunkt");

                    b.Property<string>("Titel");

                    b.HasKey("AktivitetID");

                    b.ToTable("Aktivitets");
                });

            modelBuilder.Entity("MinFritidAPI.Models.Bruger", b =>
                {
                    b.Property<int>("BrugerID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Aktiv");

                    b.Property<int>("By");

                    b.Property<string>("Efternavn");

                    b.Property<string>("Email");

                    b.Property<DateTime>("Foedselsdato");

                    b.Property<string>("Fornavn");

                    b.Property<string>("Password");

                    b.Property<bool>("Verificeret");

                    b.HasKey("BrugerID");

                    b.ToTable("Brugers");
                });
#pragma warning restore 612, 618
        }
    }
}
