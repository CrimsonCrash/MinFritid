using System;
using System.Collections.Generic;

namespace MinFritidAPI.Models
{
    internal class GetBrugerDto
    {
        public string BrugerID { get; set; }
        public string BrugerEmail { get; set; }
        public string BrugerFornavn { get; set; }
        public string BrugerEfternavn { get; set; }
        public DateTime BrugerFoedselsdag { get; set; }
        public string BrugerBynavn { get; set; }
        public bool BrugerAktiv { get; set; }
        public bool BrugerVerificeret { get; set; }
    }
}