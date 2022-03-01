using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement21A2.ViewModels
{
    public class UserViewModel
    {
        [Key]
        public int Id_user { get; set; }
        public String UserName { get; set; }
        public String Password { get; set; }
    }
}
