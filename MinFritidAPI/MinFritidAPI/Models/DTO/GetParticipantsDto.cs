using System;
using System.Collections.Generic;

namespace MinFritidAPI.Models
{
    internal class GetParticipantsDto
    {
        public string Fornavn { get; set; }
        public string Efternavn { get; set; }
        public string Bynavn { get; set; }
        public bool Verificeret { get; set; }
    }
}