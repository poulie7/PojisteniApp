﻿using System.ComponentModel.DataAnnotations;

namespace PojisteniApp.Models
{
    public class Pojistenec
    {
        
        public int  Id { get; set; }
        [Display(Name = "Jméno")]
        public string Name { get; set; }
        [Display(Name = "Příjmení")]
        public string LastName { get; set; }
        [Display(Name = "Adresa")]
        public string Adress { get; set; }
        [Display(Name = "Město")]
        public string City { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Telefon")]
        public string Phone { get; set; }
        [Display(Name = "PSČ")]
        public string PSC { get; set; }
        public List<Pojisteni>? Pojisteni { get; set; }

    }
}
