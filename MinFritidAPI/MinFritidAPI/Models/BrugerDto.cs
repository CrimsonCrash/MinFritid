using System;

namespace MinFritidAPI.Controllers
{
    internal class BrugerDto
    {
        public int BrugerID { get; set; }
        public string BrugerEmail { get; set; }
        public string BrugerFornavn { get; set; }
        public string BrugerEfternavn { get; set; }
        public DateTime BrugerFoedselsdag { get; set; }
        public int BrugerPostnummer { get; set; }
    }
}