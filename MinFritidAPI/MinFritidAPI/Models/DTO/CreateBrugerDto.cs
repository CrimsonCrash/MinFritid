﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MinFritidAPI.Models
{
    public class CreateBrugerDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Fornavn { get; set; }
        public string Efternavn { get; set; }
        public DateTime Foedselsdag { get; set; }
        public int BrugerPostnummer { get; set; }
        //public IEnumerable<Aktivitet>
    }
}