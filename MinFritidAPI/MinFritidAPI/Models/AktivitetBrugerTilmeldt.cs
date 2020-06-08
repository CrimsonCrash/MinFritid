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
        [Key]
        [Column(Order = 1)]
        [ForeignKey("Aktivetet")]
        public int AktivitetID { get; set; }
        public virtual Aktivitet Aktivitet { get; set; }

        [Key]
        [Column(Order = 2)]
        [ForeignKey("Bruger")]
        public int BrugerID { get; set; }
        public virtual Bruger Bruger { get; set; }
    }
}
