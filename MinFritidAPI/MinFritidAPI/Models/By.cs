using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MinFritidAPI.Models
{
    public class By
    {
        [Key]
        public int Postnummer { get; set; }

        public string Bynavn { get; set; }

    }
}
