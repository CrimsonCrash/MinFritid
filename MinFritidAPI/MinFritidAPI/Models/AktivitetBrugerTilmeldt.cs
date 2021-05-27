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

        [Column(Order = 2)]
        [ForeignKey("Bruger")]
        public int BrugerID { get; set; }
        public virtual Bruger Bruger { get; set; }

        public Prioritet? Prioritet { get; set; }
    }
    public enum Prioritet
    {
        Vaert = 0, // Opretteren
        Arrangoer = 1, // Arragøre kan redigere dele af aktiviteten
        Medarrangoer = 2
    }
}
