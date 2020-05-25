
using Microsoft.EntityFrameworkCore;
using MinFritidAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinFritidAPI.Data
{
    public class MinFritidContext : DbContext
    {
        public DbSet<Aktivitet> Aktivitet { get; set; }

        public DbSet<Bruger> Bruger { get; set; }

        public MinFritidContext(DbContextOptions<MinFritidContext> options) : base(options)
        {

        }
    }
}
