using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ViewModels
{
    public class StudentBasic
    {
        [Display(Name = "Student Id")]
        public int StudId { get; set; }

        [Required]
        [Display(Name = "Student voornaam")]
        public string Voornaam{ get; set; }
        [Required]
        [Display(Name = "Student Achternaam")]
        public string Achternaam { get; set; }


    }
}
