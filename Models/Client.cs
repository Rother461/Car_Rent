using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement21A2.Models
{
    public class Client
    {
        [Key]
        [Display(Name = "Id_klientaC")]
        public int Id_klienta { get; set; }

        [Required(ErrorMessage = "Podaj nazwisko klienta")]
        [Display(Name = "Nazwisko")]
        [MaxLength(50, ErrorMessage = "Max 50 char")]

        public String Nazwisko { get; set; }

        [Required(ErrorMessage = "Podaj imię klienta")]
        [Display(Name = "Imie")]
        [MaxLength(50, ErrorMessage = "Max 50 char")]


        public String Imie { get; set; }

        [Required(ErrorMessage = "Podaj adres klienta")]
        [Display(Name = "Adres")]
        [MaxLength(50, ErrorMessage = "Max 50 char")]


        public String Adres { get; set; }

        [RegularExpression(@"^[1-9]+$",
        ErrorMessage = "Nieprawidlowy format Pesel")]
        [Display(Name = "Pesel")]
        [MaxLength(11, ErrorMessage = "Max 11 char")]
        [MinLength(11, ErrorMessage = "Min 11 char")]

        public String Pesel { get; set; }

    }
}
