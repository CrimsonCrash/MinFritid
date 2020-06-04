using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MinFritidAPI.Models
{
    public class AktivitetBrugerTilmeldt
    {
        public int AktivitetID { get; set; }
        public Aktivitet Aktivitet { get; set; }

        public int BrugerID { get; set; }
        public Bruger Bruger { get; set; }
    }
}
