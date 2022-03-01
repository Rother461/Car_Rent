using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentManagement21A2.Data;
using StudentManagement21A2.Models;

namespace StudentManagement21A2.Controllers
{
    public class All_Cars_RentsController : Controller
    {
        private readonly StudentContext _context;

        public All_Cars_RentsController(StudentContext context)
        {
            _context = context;
        }
       
public IActionResult Index()
        {
            return View(_context.All_Cars_Rent.ToList()); 
        }
    }
}
