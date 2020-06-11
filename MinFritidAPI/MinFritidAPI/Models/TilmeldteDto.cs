using System;
using System.Collections.Generic;

namespace MinFritidAPI.Models
{
    internal class TilmeldteDto
    {
        public int ArrangoerID { get; set; }
        public string ArrangoerFornavn { get; set; }
        public string ArrangoerEfternavn { get; set; }
        public DateTime ArrangoerFoedselsdag { get; set; }
        public bool ArrangoerAktiv { get; set; }
    }
}