using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MinFritidAPI.Models
{
    public class Bruger
    {
        [Key]
        public int BrugerID { get; set; }
        public string Fornavn { get; set; }

        public string Efternavn { get; set; }

        public DateTime Foedselsdato { get; set; }

        public int By { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public bool Verificeret { get; set; }

    }
}
