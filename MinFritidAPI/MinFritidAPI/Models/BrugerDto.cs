using System;
using System.Collections.Generic;

namespace MinFritidAPI.Models
{
    internal class BrugerDto // TODO: Find noget at bruge denne DTO til eller slet den.
    {                        // Den blev lavet med tanken at blive brugt af GetAktivitet(int id) i AktivitetController 
                             // men endte med at bruge TilmeldtDto til at få bruger info i stedet
        public int BrugerID { get; set; }
        public string BrugerEmail { get; set; }
        public string BrugerFornavn { get; set; }
        public string BrugerEfternavn { get; set; }
        public DateTime BrugerFoedselsdag { get; set; }
        public int BrugerPostnummer { get; set; }
        public bool BrugerAktiv { get; set; }
    }
}