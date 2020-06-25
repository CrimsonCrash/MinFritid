using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MinFritidAPI.Models
{
    public class VerificerAktiverBrugerDto
    {
        public string Id { get; set; }
        public bool NyeStatus { get; set; }
    }
}