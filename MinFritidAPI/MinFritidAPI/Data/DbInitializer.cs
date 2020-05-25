using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinFritidAPI.Data
{
    public class DbInitializer
    {
        public static void Initializer(MinFritidContext context)
        {
            context.Database.EnsureCreated();

            context.SaveChanges();
        }
    }
}
