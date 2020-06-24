using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MinFritidAPI.Models
{
    public class UpdateBrugerDto
    {
        public string Id { get; set; }
        //public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Fornavn { get; set; }
        public string Efternavn { get; set; }
        public DateTime Foedselsdato { get; set; }
        public string SecurityStamp { get; set; }
        public int BrugerPostnummer { get; set; }
    }
}