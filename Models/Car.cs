using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement21A2.Models
{
    public class Car
    {
        [Key]
        public int Id_auta { get; set; }

        [Required(ErrorMessage = "Podaj klase samochodu")]
        [Display(Name = "Klasa")]
        [MaxLength(1, ErrorMessage = "Max 1 char")]

        public string Klasa { get; set; }
        [ForeignKey("Klasa")]
        public Prize Prize { get; set; }

        [Required(ErrorMessage = "Podaj marke samochodu")]
        [Display(Name = "Marka")]
        [MaxLength(50, ErrorMessage = "Max 50 char")]

        public string Marka { get; set; }

        [Required(ErrorMessage = "Podaj model samochodu")]
        [Display(Name = "Model")]
        [MaxLength(50, ErrorMessage = "Max 50 char")]

        public string Model { get; set; }

        [Required(ErrorMessage = "Podaj rocznik")]
        [Display(Name = "Rocznik")]

        public int Rocznik { get; set; }

        [Required(ErrorMessage = "Podaj kolor")]
        [Display(Name = "Kolor")]
        [MaxLength(50, ErrorMessage = "Max 50 char")]
        public String Kolor { get; set; }

        [Required(ErrorMessage = "Podaj silnik")]
        [Display(Name = "Silnik")]
        [MaxLength(50, ErrorMessage = "Max 50 char")]

        public String Silnik { get; set; }

    }
}
