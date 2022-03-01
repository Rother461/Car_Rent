using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement21A2.Models
{
    [Keyless]
    public class All_Car
    {
       
        public String Nr_rej { get; set; }
        public String Marka { get; set; }
        public String Model { get; set; }
        public int Rocznik { get; set; }
        public String Klasa { get; set; }


    }
}
