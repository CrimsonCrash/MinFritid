using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MinFritidAPI.Models
{
    public class By
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Postnummer { get; set; } 

        public string Bynavn { get; set; }

    }
}
