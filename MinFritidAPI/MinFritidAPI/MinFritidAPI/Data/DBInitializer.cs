
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinFritidAPI.Data
{
    public class DBInitializer
    {
        public static void Initializer(MinFritidContext context)
        {
            //sikre sig at databasen eksisterer
            context.Database.EnsureCreated();

            //gemmer ændringer
            context.SaveChanges();
        }
    }
}
