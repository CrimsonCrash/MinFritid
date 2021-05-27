using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MinFritidAPI.Models
{
    public class Bruger : IdentityUser
    {
        private bool verificeret = false;
        private bool aktiv = true;

        [Key]
        public int BrugerID { get; set; }

        [Required]
        public string Fornavn { get; set; }

        [Required]
        public string Efternavn { get; set; }

        [Column(TypeName = "Date")]
        public DateTime Foedselsdato { get; set; }

        public int? BrugerPostnummer { get; set; }
        [ForeignKey("BrugerPostnummer")]
        public By By { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public bool Verificeret { get => verificeret; set => verificeret = value; }
        public bool Aktiv { get => aktiv; set => aktiv = value; }

        public ICollection<AktivitetBrugerTilmeldt> AktivitetBrugerTilmeldt { get; set; }
    }
}
