using MinFritidAPI.Models;

namespace MinFritidAPI.Controllers
{
    internal class TilmeldteDto : BrugerDto
    {
        public int BrugerID { get; set; }
        public Bruger Bruger { get; set; }
    }
}