
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
        //opsætter en constructor
        public MinFritidContext()
        {
            //skal være en blank constuctor, den opretter en blank instans af context
        }

        //er et kald på Aktiviteter synlig for databasen
        public DbSet<Aktivitet> Aktivitets { get; set; }

        //er et kald på Brugerer synlig for databasen
        public DbSet<Bruger> Brugers { get; set; }

        
        public MinFritidContext(DbContextOptions<MinFritidContext> options) : base(options)
        {
            
        }
        
    }
}
