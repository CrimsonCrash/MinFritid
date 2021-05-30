﻿using Microsoft.EntityFrameworkCore;
using MinFritidAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinFritidAPI.Data
{
    public class MinFritidContext
    {
        public MinFritidContext()
        {
            //skal være en blank constuctor, den opretter en blank instans af context
        }

        public MinFritidContext(DbContextOptions<MinFritidContext> options) : base(options)
        {

        }

        //er et kald på Aktiviteter synlig for databasen
        public DbSet<Aktivitet> Aktivitet { get; set; }

        //er et kald på Brugere synlig for databasen
        public DbSet<Bruger> Bruger { get; set; }

        public DbSet<AktivitetBrugerTilmeldt> AktivitetBrugerTilmeldt { get; set; }

        public DbSet<By> By { get; set; }

        public DbSet<Admin> Admin { get; set; }
        public object Database { get; internal set; }
    }
}