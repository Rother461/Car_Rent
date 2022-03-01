using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement21A2.Models
{
    public class Rent
    {
        [Key]
        public int Id_wynajmu { get; set; }

        [Display(Name = "Id_klientaR")]
        public int Id_klienta { get; set; }
        [ForeignKey("Id_klienta")]
        public Client Client { get; set; }

        [Required(ErrorMessage = "Podaj nr.rejestracyjny")]
        [Display(Name = "Nr_rej")]
        [MaxLength(9, ErrorMessage = "Max 9 char")]
        public String Nr_rej { get; set; }
        [ForeignKey("Nr_rej")]
        public CopyCar CopyCar { get; set; }

        public DateTime Data_od { get; set; }

        public DateTime Data_do { get; set; }
    }
}
