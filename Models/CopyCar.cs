using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement21A2.Models
{
    public class CopyCar
    {
        [Key]
        [MaxLength(9, ErrorMessage = "Max 9 char")]
        public String Nr_rej { get; set; }

        public int Id_auta { get; set; }
        [ForeignKey("Id_auta")]
        public Car Car { get; set; }
       
       
    }
}
