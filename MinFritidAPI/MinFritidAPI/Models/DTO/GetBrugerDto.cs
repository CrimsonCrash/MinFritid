using System;
using System.Collections.Generic;

namespace MinFritidAPI.Models
{
    internal class GetBrugerDto
    {
        /*public int BrugerID { get; set; }*/
        public string BrugerEmail { get; set; }
        public string BrugerFornavn { get; set; }
        public string BrugerEfternavn { get; set; }
        public DateTime BrugerFoedselsdag { get; set; }
        public int? BrugerPostnummer { get; set; }
        public bool BrugerAktiv { get; set; }
    }
}