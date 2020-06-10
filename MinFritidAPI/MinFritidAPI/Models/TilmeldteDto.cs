using System;
using System.Collections.Generic;

namespace MinFritidAPI.Models
{
    internal class TilmeldteDto
    {
        public int BrugerID { get; set; }
        public string BrugerFornavn { get; set; }
        public string BrugerEfternavn { get; set; }
        public DateTime BrugerFoedselsdag { get; set; }
        public bool BrugerAktiv { get; set; }
    }
}