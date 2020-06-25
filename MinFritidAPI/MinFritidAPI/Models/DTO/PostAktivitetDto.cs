using System;
using System.Collections.Generic;

namespace MinFritidAPI.Models
{
    public class PostAktivitetDto
    {
        public int BrugerID { get; set; }
        public string Titel { get; set; }
        public string Beskrivelse { get; set; }
        public string Huskeliste { get; set; }
        public int Pris { get; set; }
        public int MaxDeltagere { get; set; }
        public DateTime StartTidspunkt { get; set; }
        public DateTime SlutTidspunkt { get; set; }
        public int? Postnummer { get; set; }
    }
}