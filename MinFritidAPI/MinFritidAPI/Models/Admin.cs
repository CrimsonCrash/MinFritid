﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MinFritidAPI.Models
{
    public class Admin
    {
        [ForeignKey("BrugerID")]
        public int AdminID { get; set; }
    }
}
