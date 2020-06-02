using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MinFritidAPI.Models
{
    public class Aktivitet
    {
        [Key]
        public int ID { get; set; }

        public int BrugerID { get; set; }

        public string Titel { get; set; }

        public string Beskrivelse { get; set; }

        public string Huskeliste { get; set; }

        public int Pris { get; set; }

        public int MaxDeltagere { get; set; }

        public DateTime StartTidspunkt { get; set; }

        public DateTime SlutTidspunkt { get; set; }

        public int PostNummer { get; set; }

        public bool Aktiv { get; set; }
    }
}
