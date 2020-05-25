
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
        public DbSet<Aktivitet> Aktivitets { get; set; }

        public DbSet<Bruger> Brugers { get; set; }

        public MinFritidContext(DbContextOptions<MinFritidContext> options) : base(options)
        {

        }
    }
}
