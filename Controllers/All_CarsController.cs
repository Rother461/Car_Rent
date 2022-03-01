using Microsoft.AspNetCore.Mvc;
using StudentManagement21A2.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement21A2.Controllers
{
    public class All_CarsController : Controller
    {
        private readonly StudentContext _context;

        public All_CarsController(StudentContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.All_Car.ToList());
        }
    }
}