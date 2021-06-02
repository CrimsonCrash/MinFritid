using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MinFritidAPI.Models
{
    public class Aktivitet
    {
        private bool aktiv = true;

        [Key]
        public int AktivitetID { get; set; }
        
        public string Titel { get; set; }

        public string Beskrivelse { get; set; }

        public string Huskeliste { get; set; }

        public int Pris { get; set; }

        public int MaxDeltagere { get; set; }

        public DateTime StartTidspunkt { get; set; }

        public DateTime SlutTidspunkt { get; set; }

        public int? Postnummer { get; set; }
        [ForeignKey("Postnummer")]
        public By By { get; set; }

        public bool Aktiv { get => aktiv; set => aktiv = value; }

        public ICollection<AktivitetBrugerTilmeldt> AktivitetBrugerTilmeldt { get; set; }
    }
}
