using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement21A2.Models
{
    public class Prize
    {
        [Key]
        [MaxLength(1, ErrorMessage = "Max 1 char")]
        [Display(Name = "Klasa")]
        public String Klasa { get; set; }

        [Required(ErrorMessage = "Podaj opis")]
        [Display(Name = "Opis")]
        [MaxLength(50, ErrorMessage = "Max 50 char")]

        public String Opis { get; set; }

        [Required(ErrorMessage = "Podaj cenę za dobę")]
        [Display(Name = "Cena")]

        public int Cena { get; set; }
    }
}
