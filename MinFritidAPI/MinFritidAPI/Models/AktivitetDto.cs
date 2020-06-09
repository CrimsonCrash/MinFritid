using System.Collections.Generic;

namespace MinFritidAPI.Controllers
{
    internal class AktivitetDto
    {
        public int AktivitetID { get; set; }
        public string Titel { get; set; }
        public string Beskrivelse { get; set; }
        public IEnumerable<BrugerDto> ABTilmeldt { get; set; }
    }
}