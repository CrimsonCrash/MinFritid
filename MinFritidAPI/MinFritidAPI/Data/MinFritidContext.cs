
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MinFritidAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinFritidAPI.Data
{
    public class MinFritidContext : IdentityDbContext<IdentityUser>
    {
        //opsætter en constructor
        public MinFritidContext()
        {
            //skal være en blank constuctor, den opretter en blank instans af context
        }

        public MinFritidContext(DbContextOptions<MinFritidContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityRole>().HasData(
                new { Id = "1", Name = "Admin", NormalizedName = "ADMIN" },
                new { Id = "2", Name = "Bruger", NormalizedName = "BRUGER" }
            );

            // Her sætter vi AktivitetID og BrugerID som en composite key
            modelBuilder.Entity<AktivitetBrugerTilmeldt>()
                .HasKey(abt => new { abt.AktivitetID, abt.BrugerID });
            modelBuilder.Entity<AktivitetBrugerTilmeldt>()
                .HasOne(ab => ab.Bruger)
                .WithMany(b => b.AktivitetBrugerTilmeldt)
                .HasForeignKey(ab => ab.BrugerID);
            modelBuilder.Entity<AktivitetBrugerTilmeldt>()
                .HasOne(ab => ab.Aktivitet)
                .WithMany(a => a.AktivitetBrugerTilmeldt)
                .HasForeignKey(ab => ab.AktivitetID);

            modelBuilder
                .Entity<AktivitetBrugerTilmeldt>()
                .Property(e => e.Prioritet)
                .HasConversion(
                    v => v.ToString(),
                    v => (Prioritet)Enum.Parse(typeof(Prioritet), v));

            modelBuilder.Entity<Bruger>().ToTable("Bruger");
            modelBuilder.Entity<Aktivitet>().ToTable("Aktivitet");
        }

        //er et kald på Aktiviteter synlig for databasen
        public DbSet<Aktivitet> Aktivitet { get; set; }

        //er et kald på Brugere synlig for databasen
        public DbSet<Bruger> Bruger { get; set; }

        public DbSet<AktivitetBrugerTilmeldt> AktivitetBrugerTilmeldt { get; set; }

        public DbSet<By> By { get; set; }

        public DbSet<Admin> Admin { get; set; }

    }
}
