using System;
using System.Collections.Generic;

namespace MinFritidAPI.Models
{
    internal class GetAktivitetDto
    {
        public int AktivitetID { get; set; }
        public string Titel { get; set; }
        public string Beskrivelse { get; set; }
        public string Huskeliste { get; set; }
        public int Pris { get; set; }
        public int MaxDeltagere { get; set; }
        public DateTime StartTidspunkt { get; set; }
        public DateTime SlutTidspunkt { get; set; }
        public string AktivitetBynavn { get; set; }
        public bool Aktiv { get; set; }
        public IEnumerable<GetAktivitetDto> Deltagere { get; set; }
    }
}